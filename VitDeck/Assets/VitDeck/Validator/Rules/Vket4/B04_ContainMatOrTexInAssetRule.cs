using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;
using System.IO;

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
                var staticObject = rootObject.transform.Find("Static");
                var dynamicObject = rootObject.transform.Find("Dynamic");

                if (staticObject == null && dynamicObject == null)
                {
                    continue;
                }

                LogicForRoot(rootObject);
            }
        }

        private void LogicForRoot(GameObject obj)
        {
            var renderers = obj.GetComponentsInChildren<Renderer>(true);

            var materials = new List<Material>();
            var textures = new List<Texture>();

            foreach (var renderer in renderers)
            {
                materials.AddRange(renderer.sharedMaterials);
            }

            materials = materials.Distinct().ToList();

            string path, ext;
            foreach (var material in materials)
            {
                path = AssetDatabase.GetAssetPath(material);
                ext = Path.GetExtension(path).ToLower();

                Debug.Log(path);

                if (!ext.Equals(".mat"))
                {
                    AddIssue(new Issue(
                        material, 
                        IssueLevel.Error, 
                        "アセット内に埋め込まれているMaterialを使用しています。",
                        "ExtractMaterialsを選択して出力されたMaterialを使用してください。"));
                }

                textures.AddRange(GetTexturesInMaterial(material));
            }

            textures = textures.Distinct().ToList();

            var textureExtensions = new string[]{ ".psd", ".tiff", ".jpg", ".jpeg", ".tga", ".png", "gif", "bmp", "iff", "pict" };
            foreach (var texture in textures)
            {
                path = AssetDatabase.GetAssetPath(texture);
                ext = Path.GetExtension(path).ToLower();

                if (textureExtensions.Contains(ext))
                {
                    AddIssue(new Issue(
                        texture, 
                        IssueLevel.Error, 
                        "アセット内に埋め込まれているTextureを使用しています。",
                        "ExtractTexturesを選択して出力されたTextureを使用してください。"));
                }
            }
        }

        private List<Texture> GetTexturesInMaterial(Material material)
        {
            var textures = new List<Texture>();

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