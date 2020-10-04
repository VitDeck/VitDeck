#if VRC_SDK_VRCSDK3
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using VitDeck.Language;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

namespace VitDeck.Validator
{
    /// <summary>
    /// PhysicsクラスのCast関数 layerMaskを設定し、レイヤー23以外のコライダを無視するようにする, maxDistanceは最長で10メートルまで
    /// </summary>
    /// <remarks>
    /// UdonAssemblyを調査し、特定の関数の引数が使用されているか、正しい値が設定されているかを調査します。
    /// プレハブのGUIDを与えることで、そのプレハブに元から追加してあるコンポーネントを許可されているものとして無視します。
    /// 値の確認は定数のみ UdonSharpで定義しているときは private const で UdonNodeで定義している場合は値を直接指定する方法のみサポート
    /// </remarks>
    internal class UdonAssemblyPhysicsCastFunctionRule : BaseUdonBehaviourRule
    {
        private const float _maxDistance = 10.0f; // 0.0f < x <= 10.0f あれば任意
        private const int _layerMask = 8388608;  // Layer23 mask (固定値)

        private readonly UdonAssemblyFunctionEssentialArgumentReference[] references;

        public enum AssemblyArgumentReferenceError
        {
            NoErrors, InvalidArguments, MaxDistanceError, LayerMaskError
        }

        private readonly HashSet<string> ignorePrefabs;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="name">ルール名</param>
        /// <param name="references">アセンブリリスト</param>
        /// <param name="ignorePrefabGUIDs">例外Prefabのリスト</param>
        public UdonAssemblyPhysicsCastFunctionRule(string name,
            UdonAssemblyFunctionEssentialArgumentReference[] references,
            string[] ignorePrefabGUIDs = null)
            : base(name)
        {
            this.references = references ?? new UdonAssemblyFunctionEssentialArgumentReference[] { };
            if (ignorePrefabGUIDs == null)
            {
                ignorePrefabGUIDs = new string[0];
            }
            ignorePrefabs = new HashSet<string>(ignorePrefabGUIDs);
        }

        protected override void ComponentLogic(UdonBehaviour component)
        {
            bool isIgnorePrefabInstance = IsIgnoredPrefab(component.gameObject);
            var isPrefabComponent = !PrefabUtility.IsAddedComponentOverride(component);
            if (isIgnorePrefabInstance && isPrefabComponent) return;
            
            // UdonProgramName
            var programName = component.programSource.name;

            // プログラム
            var program = GetUdonProgram(component);
            var heap = program?.Heap;

            // コード
            var code = GetDisassembleCode(program);

            // 探索
            var rows = code.Replace("\r\n","\n").Split(new[]{'\n','\r'});
            var rowNum = 1;
            List<uint> pushStack = new List<uint>();
            foreach (var row in rows)
            {
                var assembly = row.Split(' ');
                foreach (var reference in references)
                {
                    // ターゲットの関数検索
                    if (reference == null || !reference.ExistsTargetFunction(row)) continue;
                    if (reference.ExistsEssentialArguments(row))
                    {
                        // エラーの分類
                        var _error = CheckArgumentValues(heap, pushStack, assembly[2].Trim('"'), reference.essentialArgument, out var detail);
                        switch (_error)
                        {
                            case AssemblyArgumentReferenceError.InvalidArguments:
                                AddIssue(new Issue(component, IssueLevel.Error,
                                    LocalizedMessage.Get("UdonAssemblyPhysicsCastFunctionRule.InvalidArguments", reference.name, row, rowNum),
                                    LocalizedMessage.Get("UdonAssemblyPhysicsCastFunctionRule.InvalidArguments.Solution", reference.name, reference.essentialsName),
                                    string.Empty));
                                break;
                            case AssemblyArgumentReferenceError.MaxDistanceError:
                                AddIssue(new Issue(component, IssueLevel.Error,
                                    LocalizedMessage.Get("UdonAssemblyPhysicsCastFunctionRule.MaxDistanceError", reference.name, row, rowNum, detail),
                                    LocalizedMessage.Get("UdonAssemblyPhysicsCastFunctionRule.MaxDistanceError.Solution", reference.name, reference.essentialsName, _maxDistance),
                                    string.Empty));
                                break;
                            case AssemblyArgumentReferenceError.LayerMaskError:
                                AddIssue(new Issue(component, IssueLevel.Error,
                                    LocalizedMessage.Get("UdonAssemblyPhysicsCastFunctionRule.LayerMaskError", reference.name, row, rowNum, detail),
                                    LocalizedMessage.Get("UdonAssemblyPhysicsCastFunctionRule.LayerMaskError.Solution", reference.name, reference.essentialsName, _layerMask),
                                    string.Empty));
                                break;
                        }
                    }
                    else
                    {
                        AddIssue(new Issue(component, IssueLevel.Error,
                            LocalizedMessage.Get("UdonAssemblyPhysicsCastFunctionRule.InvalidArguments", reference.name, row, rowNum),
                            LocalizedMessage.Get("UdonAssemblyPhysicsCastFunctionRule.InvalidArguments.Solution", reference.name, reference.essentialsName),
                            string.Empty));
                    }
                }

                // PUSHスタックを集める
                if (assembly[1] == "PUSH,")
                {
                    pushStack.Add( Convert.ToUInt32(assembly[2].Trim(), 16));
                }
                else
                {
                    pushStack.Clear();
                }
                rowNum++;
            }
        }

        private bool IsIgnoredPrefab(GameObject obj)
        {
            if (PrefabUtility.GetPrefabType(obj) != PrefabType.PrefabInstance)
            {
                return false;
            }

            var asset = PrefabUtility.GetPrefabParent(obj);
            var path = AssetDatabase.GetAssetPath(asset);
            var guid = AssetDatabase.AssetPathToGUID(path);

            if (ignorePrefabs.Contains(guid))
            {
                return true;
            }
            return false;
        }

        private AssemblyArgumentReferenceError CheckArgumentValues(IUdonHeap heap, List<uint> stack, string assembly, string arguments, out string detail)
        {
            var desiredArgs = arguments.Trim('_').Split('_');
            var phrases = Regex.Split(assembly, "__");
            var args = phrases[2].Split('_');
            // 引数の構造的に最後の型一致が求める引数になる Physics.*Cast の引数構造がある前提
            var hit = Array.LastIndexOf(args, desiredArgs[0]);
            if (desiredArgs.Length == 2)
            {
                // *Cast は 2引数セットで揃っている
                if (args[hit + 1] == desiredArgs[1])
                {
                    // 見つかった
                    var maxDistance = heap.GetHeapVariable<float>(stack[hit]); // distance
                    var layerMask = heap.GetHeapVariable<int>(stack[hit + 1]); // layermask
                    if (maxDistance > _maxDistance)
                    {
                        // MaxDistanceエラー
                        detail = maxDistance.ToString();
                        return AssemblyArgumentReferenceError.MaxDistanceError;
                    }

                    if (layerMask != _layerMask)
                    {
                        // layerMaskエラー
                        detail = layerMask.ToString();
                        return AssemblyArgumentReferenceError.LayerMaskError;
                    }
                }
                else
                {
                    // 引数エラー
                    detail = "";
                    return AssemblyArgumentReferenceError.InvalidArguments;
                }
            }
            else
            {
                // LineCastの場合のみ
                var layerMask = heap.GetHeapVariable<int>(stack[hit]); // layermask
                if (layerMask != _layerMask)
                {
                    // layerMaskエラー
                    detail = layerMask.ToString();
                    return AssemblyArgumentReferenceError.LayerMaskError;
                }
            }

            // 何もない
            detail = "";
            return AssemblyArgumentReferenceError.NoErrors;
        }
    }
}
#endif
