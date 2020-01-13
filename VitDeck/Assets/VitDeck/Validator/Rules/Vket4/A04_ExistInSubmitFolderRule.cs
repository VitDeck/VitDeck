using System;
using UnityEditor;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace VitDeck.Validator
{
	/// <summary>
	/// 配布物以外のすべてのオブジェクトが入稿フォルダ内にあるか検出するルール
	/// <summary>
    public class A04_ExistInSubmitFolderRule : BaseRule
    {
        // 入稿フォルダに含めることを許可されていないGUID
        private readonly HashSet<string> unauthorizedIDSet;
        public A04_ExistInSubmitFolderRule(string name, string[] guids) : base(name)
        {
            unauthorizedIDSet = new HashSet<string>(guids);
        }

        protected override void Logic(ValidationTarget target)
        {
            // 除外する配布物アセットのパス
            var excludePaths = unauthorizedIDSet
                .Select(guid => AssetDatabase.GUIDToAssetPath(guid));

            // 入稿フォルダ内および出展物から参照されるすべてのアセットのパス
            var allAssetPaths = target.GetAllAssetPaths();
            var submitDirectory = target.GetBaseFolderPath();

            foreach (var assetPath in allAssetPaths)
            {
                var dependencyPaths = AssetDatabase
                    .GetDependencies(assetPath);

                foreach (var dependencyPath in dependencyPaths)
                {
                    if (excludePaths.Contains(dependencyPath))
                        continue;

                    if (!dependencyPath.StartsWith(submitDirectory))
                    {   
                        var referenceObject = AssetDatabase.LoadMainAssetAtPath(dependencyPath);
                        var message = String.Format("アセット{0}が入稿フォルダ内に含まれていません。", dependencyPath);
                        var solution = String.Format("入稿するアセットは(運営から配布されたアセットを除いて)すべてAssetsフォルダ直下の「出展者ID」フォルダ以下に配置してください。");
                        AddIssue(new Issue(referenceObject, IssueLevel.Error, message, solution));
                    }
                }
            }
        }
    }
}