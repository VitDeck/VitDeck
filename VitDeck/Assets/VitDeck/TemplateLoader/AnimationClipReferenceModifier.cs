using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace VitDeck.TemplateLoader
{
    /// <summary>
    /// AnimationClipアセットファイルのアニメーション対象のオブジェクト名を置換する。
    /// </summary>
    internal class AnimationClipReferenceModifier : IReferenceModifier
    {
        private Dictionary<string, string> replaceNamePairDictionary;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="_replaceNamePairDictionary">オブジェクト名に含まれる置換前、置換後の文字列のペア</param>
        public AnimationClipReferenceModifier(Dictionary<string, string> _replaceNamePairDictionary)
        {
            this.replaceNamePairDictionary = _replaceNamePairDictionary;
        }

        public void Modify(string path)
        {
            var clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(path);
            if (clip == null)
                return;
            var bindings = AnimationUtility.GetCurveBindings(clip);
            var newPaths = new string[bindings.Length];
            var findFlag = false;
            for (int i = 0; i < bindings.Length; i++)
            {
                var binding = bindings[i];
                newPaths[i] = binding.path;
                foreach (var key in replaceNamePairDictionary.Keys)
                {
                    if (newPaths[i].Contains(key))
                    {
                        newPaths[i] = newPaths[i].Replace(key, replaceNamePairDictionary[key]);
                        findFlag = true;
                    }
                }
            }
            if (findFlag)
            {
                var newClip = new AnimationClip();
                EditorUtility.CopySerialized(clip, newClip);
                newClip.ClearCurves();
                for (int i = 0; i < bindings.Length; i++)
                {
                    var binding = bindings[i];
                    var curve = AnimationUtility.GetEditorCurve(clip, binding);
                    newClip.SetCurve(newPaths[i], binding.type, binding.propertyName, curve);
                }
                AssetDatabase.CreateAsset(newClip, path);
            }
        }
    }
}