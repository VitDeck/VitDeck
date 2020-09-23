#if VRC_SDK_VRCSDK3
using System;
using System.Collections.Generic;
using UnityEngine;
using VRC.Udon;
using VRC.Udon.Editor.ProgramSources;
using VRC.Udon.Editor.ProgramSources.UdonGraphProgram;
using VRC.Udon.Graph;
using VRC.Udon.ProgramSources;
using VRC.Udon.UAssembly.Disassembler;

namespace VitDeck.Validator
{
    internal class BaseUdonBehaviourRule : ComponentBaseRule<UdonBehaviour>
    {
        public BaseUdonBehaviourRule(string name) : base(name)
        {
        }

        protected override void ComponentLogic(UdonBehaviour component)
        {
            // UdonProgramName
            var name = component.programSource.name;
            Debug.Log(name);

            // ノード一覧
            var graph = GetGraphData(component);
            if (graph != null)
            {
                List<string> nodeNames = new List<string>();
                foreach (var node in graph.nodes)
                {
                    nodeNames.Add(node.fullName);
                }
                Debug.Log(String.Join("\n", nodeNames));
            }

            // コード
            Debug.Log(GetDisassembleCode(component));
        }

        protected override void HasComponentObjectLogic(GameObject hasComponentObject)
        {
        }

        /// <summary>
        /// バイトコードからのディスアセンブル
        /// </summary>
        /// <param name="component">VRC.Udon.UdonBehaviour</param>
        /// <returns>string</returns>
        protected static string GetDisassembleCode(UdonBehaviour component)
        {
            if (component.programSource is UdonAssemblyProgramAsset)
            {
                var programAsset = component.programSource as UdonAssemblyProgramAsset;
                if (programAsset.SerializedProgramAsset is SerializedUdonProgramAsset)
                {
                    var serializedProgram = programAsset.SerializedProgramAsset as SerializedUdonProgramAsset;
                    var program = serializedProgram.RetrieveProgram();
                    var disasm = new UAssemblyDisassembler();
                    return String.Join("\n", disasm.DisassembleProgram(program));
                }
            }

            return null;
        }

        /// <summary>
        /// UdonGraphの取り出し
        /// </summary>
        /// <param name="component">VRC.Udon.UdonBehaviour</param>
        /// <returns>VRC.Udon.Graph.UdonGraphData</returns>
        protected static UdonGraphData GetGraphData(UdonBehaviour component)
        {
            if (component.programSource is UdonGraphProgramAsset)
            {
                var programAsset = component.programSource as UdonGraphProgramAsset;
                return programAsset.GetGraphData();
            }

            return null;
        }
    }
}
#endif
