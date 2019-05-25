using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace VitDeck.TemplateLoader
{
    /// <summary>
    /// FBXファイルのguid参照を置換する機能を提供する。
    /// </summary>
    /// <remarks>FBXファイルはマテリアルのリマップを参照として持つ。</remarks>
    internal class FbxReferenceModifier : IReferenceModifier
    {
        Dictionary<string, string> replaceGuidPairDictionary;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="_replaceGuidPairDictionary">置換前guid、置換後guidをペアとする辞書</param>
        public FbxReferenceModifier(Dictionary<string, string> _replaceGuidPairDictionary)
        {
            replaceGuidPairDictionary = _replaceGuidPairDictionary;
        }

        public void Modify(string path)
        {
            if (replaceGuidPairDictionary == null ||
                path == null ||
                !Path.GetExtension(path).Equals(".fbx", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            var modelImporter = ModelImporter.GetAtPath(path);
            var map = modelImporter.GetExternalObjectMap();
            foreach (var pair in map)
            {
                if (pair.Value is Material)
                {
                    var mat = pair.Value as Material;
                    var matPath = AssetDatabase.GetAssetPath(mat.GetInstanceID());
                    var matGuid = AssetDatabase.AssetPathToGUID(matPath);
                    if (replaceGuidPairDictionary.ContainsKey(matGuid))
                    {
                        var newMatPath = AssetDatabase.GUIDToAssetPath(replaceGuidPairDictionary[matGuid]);
                        var newMat = AssetDatabase.LoadAssetAtPath<Material>(newMatPath);
                        modelImporter.RemoveRemap(pair.Key);
                        modelImporter.AddRemap(pair.Key, newMat);
                    }
                }
            }
            AssetDatabase.WriteImportSettingsIfDirty(path);
        }
    }
}