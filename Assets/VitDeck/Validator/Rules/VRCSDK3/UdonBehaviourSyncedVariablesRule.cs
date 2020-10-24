#if VRC_SDK_VRCSDK3
using System;
using UnityEngine;
using VitDeck.Language;

using VRC.Udon;

namespace VitDeck.Validator
{
    /// <summary>
    /// [UdonSynced]を付与した変数は1ブースあたり 3 まで
    /// [UdonSynced]を付与した変数は下記の型のみ使用できます bool, sbyte, byte, ushort, short, uint, int, float
    /// </summary>
    public class UdonBehaviourSyncedVariablesRule : BaseRule
    {
        private readonly int _limit;
        public UdonBehaviourSyncedVariablesRule(string name, int limit) : base(name)
        {
            this._limit = limit;
        }

        protected override void Logic(ValidationTarget target)
        {
            var rootObjs = target.GetRootObjects();

            foreach (var rootObj in rootObjs)
            {
                LogicForRootObject(rootObj);
            }
        }

        private void LogicForRootObject(GameObject rootObject)
        {
            var udonBehaviours = rootObject.GetComponentsInChildren<UdonBehaviour>(true);
            var count = 0;
            foreach (var udonBehaviour in udonBehaviours)
            {
                // ProgramSourceが無い場合はスキップ
                if (udonBehaviour.programSource == null) continue;
                // プログラムアセットを取得する
                var program = udonBehaviour.programSource.SerializedProgramAsset.RetrieveProgram();
                // SyncMetadataTableが無ければスキップ
                if (program.SyncMetadataTable == null) continue;
                
                // UdonSymcMetadata取得
                var syncs = program.SyncMetadataTable.GetAllSyncMetadata();
                foreach (var sync in syncs)
                {
                    // Sync変数の型を評価
                    var symbolType = program.SymbolTable.GetSymbolType(sync.Name);
                    if (!IsValidType(symbolType))
                    {
                        AddIssue(new Issue(
                            udonBehaviour,
                            IssueLevel.Error,
                            LocalizedMessage.Get("UdonBehaviourSyncedVariablesRule.InvalidType", sync.Name, symbolType.Name),
                            LocalizedMessage.Get("UdonBehaviourSyncedVariablesRule.InvalidType.Solution")));
                    }
 
                    count++;
                }
            }

            if (count > _limit)
            {
                AddIssue(new Issue(
                    rootObject,
                    IssueLevel.Error,
                    LocalizedMessage.Get("UdonBehaviourSyncedVariablesRule.Overuse", _limit, count),
                    LocalizedMessage.Get("UdonBehaviourSyncedVariablesRule.Overuse.Solution")));
            }
        }

        private bool IsValidType(Type variableType)
        {
            // bool, sbyte, byte, ushort, short, uint, int, float のいずれかの型判定
            return (
                variableType == typeof(bool) ||
                variableType == typeof(sbyte) ||
                variableType == typeof(byte) ||
                variableType == typeof(ushort) ||
                variableType == typeof(short) ||
                variableType == typeof(uint) ||
                variableType == typeof(int) ||
                variableType == typeof(float)
                );
        }
    }
}
#endif
