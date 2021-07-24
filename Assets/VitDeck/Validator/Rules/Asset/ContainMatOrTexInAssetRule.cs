using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;
using System.IO;
using VitDeck.Language;

namespace VitDeck.Validator
{
    /// <summary>
    /// アセット内のMaterialやTextureの埋め込みを検証するルール
    /// </summary>
    public class ContainMatOrTexInAssetRule : BaseRule
    {
        public ContainMatOrTexInAssetRule(string name) : base(name)
        {
        }

        protected override void Logic(ValidationTarget target)
        {
            var rootObjects = target.GetRootObjects();

            foreach (var rootObject in rootObjects)
            {
                LogicForRoot(rootObject);
            }
        }

        private void LogicForRoot(GameObject obj)
        {
            var renderers = obj.GetComponentsInChildren<Renderer>(true);

            foreach (var renderer in renderers)
            {
                if (PrefabUtility.GetPrefabAssetType(renderer.gameObject) == PrefabAssetType.NotAPrefab)
                {
                    continue;
                }

                var prefabAsset = PrefabUtility.GetCorrespondingObjectFromSource(renderer.gameObject);
                var prefabAssetPath = AssetDatabase.GetAssetPath(prefabAsset);

                foreach (var material in renderer.sharedMaterials)
                {
                    var matAssetPath = AssetDatabase.GetAssetPath(material);

                    if (matAssetPath.Equals(prefabAssetPath))
                    {
                        AddIssue(new Issue(
                            material,
                            IssueLevel.Error,
                            LocalizedMessage.Get("ContainMatOrTexInAssetRule.EmbeddedMaterial"),
                            LocalizedMessage.Get("ContainMatOrTexInAssetRule.EmbeddedMaterial.Solution")));
                    }

                    var textures = GetTexturesInMaterial(material);

                    foreach (var texture in textures)
                    {
                        var texAssetPath = AssetDatabase.GetAssetPath(texture);

                        if (texAssetPath.Equals(prefabAssetPath))
                        {
                            AddIssue(new Issue(
                                texture,
                                IssueLevel.Error,
                                LocalizedMessage.Get("ContainMatOrTexInAssetRule.EmbeddedTexture"),
                                LocalizedMessage.Get("ContainMatOrTexInAssetRule.EmbeddedTexture.Solution")));
                        }
                    }
                }
            }
        }

        private List<Texture> GetTexturesInMaterial(Material material)
        {
            var textures = new List<Texture>();

            if (material == null)
            {
                return textures;
            }
            var shader = material.shader;
            var shaderPropertyCount = ShaderUtil.GetPropertyCount(material.shader);

            for (int i = 0; i < shaderPropertyCount; i++)
            {
                var propertyType = ShaderUtil.GetPropertyType(shader, i);
                if (propertyType != ShaderUtil.ShaderPropertyType.TexEnv)
                {
                    continue;
                }

                var propertyName = ShaderUtil.GetPropertyName(shader, i);
                var texture = material.GetTexture(propertyName);
                if (texture != null)
                {
                    textures.Add(texture);
                }
            }
            return textures;
        }
    }
}