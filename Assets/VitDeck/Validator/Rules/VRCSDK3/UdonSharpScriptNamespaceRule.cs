#if VRC_SDK_VRCSDK3
using System;
using UdonSharp;
using UnityEditor;
using UnityEngine;
using VitDeck.Language;

namespace VitDeck.Validator
{
    /// <summary>
    /// 特定ディレクトリ /UdonScript/ 以下の MonoScript(*.cs) はUdonSharpのスクリプトと見なす
    /// UdonSharpのスクリプトは UdonSharpBehaviour を継承していなければならない
    /// U#においては、全てのクラスは運営よりブース毎に指定するnamespaceに所属させてください
    /// </summary>
    public class UdonSharpScriptNamespaceRule : BaseRule
    {
        public UdonSharpScriptNamespaceRule(string name) : base(name)
        {
        }

        protected override void Logic(ValidationTarget target)
        {
            var rootObjects = target.GetRootObjects();
            var rootPath = target.GetBaseFolderPath();
            var assetObjects = target.GetAllAssets();
            var assetPaths = target.GetAllAssetPaths();
            for (var i = 0; i < assetObjects.Length; i++)
            {
                var asset = assetObjects[i];
                var path = assetPaths[i];
                if (!(path.IndexOf(rootPath, StringComparison.Ordinal) == 0 && path.Length > rootPath.Length))
                {
                    continue;
                }
                var localPath = path.Substring(rootPath.Length + 1);
                if (localPath.IndexOf("UdonScript/", StringComparison.Ordinal) == 0 &&  asset is MonoScript src)
                {
                    // Debug.Log("path: " + path + " Object: " + src.name + " Class: " + src.GetClass() + "");
                    // U# スクリプトは UdonSharpBehaviour を継承していなければならない
                    if (!src.GetClass().IsSubclassOf(typeof(UdonSharpBehaviour)))
                    {
                        AddIssue(new Issue(asset, IssueLevel.Error, LocalizedMessage.Get("UdonSharpScriptNamespaceRule.NotUdonSharp", src.GetClass())));
                    }
                    // U# スクリプトは 正しい名前空間で定義されなければならない
                    if (src.GetClass().ToString().IndexOf('.') == -1)
                    {
                        AddIssue(
                            new Issue(
                                asset, 
                                IssueLevel.Error, 
                                LocalizedMessage.Get("UdonSharpScriptNamespaceRule.InvalidNamespace"),
                                LocalizedMessage.Get("UdonSharpScriptNamespaceRule.InvalidNamespace.solution", src.GetClass())
                                )
                            );
                    }
                }
            }
        }
    }
}
#endif
