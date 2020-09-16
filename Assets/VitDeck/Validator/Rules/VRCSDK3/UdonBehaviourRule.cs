#if VRC_SDK_VRCSDK3
using System;
using System.Collections.Generic;
using UnityEngine;
using VRC.Udon;
using VRC.Udon.Editor.ProgramSources;
using VRC.Udon.Editor.ProgramSources.UdonGraphProgram;
using VRC.Udon.ProgramSources;
using VRC.Udon.UAssembly.Disassembler;

namespace VitDeck.Validator
{
    internal class UdonBehaviourRule : ComponentBaseRule<UdonBehaviour>
    {
        public UdonBehaviourRule(string name) : base(name)
        {
        }

        protected override void ComponentLogic(UdonBehaviour component)
        {
            var type = component.programSource.GetType();
            Debug.Log(type.ToString());

            // ノード一覧の書き出し
            if (component.programSource is UdonGraphProgramAsset)
            {
                var programAsset = component.programSource as UdonGraphProgramAsset;
                Debug.Log(programAsset.ToString());
                var graph = programAsset.GetGraphData();
                List<string> nodeNames = new List<string>();
                foreach (var node in graph.nodes)
                {
                    nodeNames.Add(node.fullName);
                }
                Debug.Log(String.Join("\n", nodeNames));
            }

            // バイトコードからのディスアセンブル
            if (component.programSource is UdonAssemblyProgramAsset)
            {
                var programAsset = component.programSource as UdonAssemblyProgramAsset;
                Debug.Log(programAsset.ToString());
                Debug.Log(programAsset.SerializedProgramAsset.GetType().ToString());
                if (programAsset.SerializedProgramAsset is SerializedUdonProgramAsset)
                {
                    var serializedProgram = programAsset.SerializedProgramAsset as SerializedUdonProgramAsset;
                    var program = serializedProgram.RetrieveProgram();
                    var disasm = new UAssemblyDisassembler();
                    Debug.Log(String.Join("\n", disasm.DisassembleProgram(program))); ;
                }
            }
        }

        protected override void HasComponentObjectLogic(GameObject hasComponentObject)
        {
            Debug.Log("UdonBehaviour Validation Test");
        }
    }
}
#endif
