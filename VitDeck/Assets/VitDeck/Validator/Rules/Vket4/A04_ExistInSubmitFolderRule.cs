using System;
using UnityEditor;
using UnityEngine;

namespace VitDeck.Validator
{
	/// <summary>
	/// 配布物以外のすべてのオブジェクトが入稿フォルダ内にあるか検出するルール
	/// <summary>
    public class A04_ExistInSubmitFolderRule : BaseRule
    {
        public A04_ExistInSubmitFolderRule(string name) : base(name)
        {
        }

        protected override void Logic(ValidationTarget target)
        {
            // 入稿フォルダ内および出展物から参照されるすべてのアセットのパス
            var allAssetPaths = target.GetAllAssetPaths();

            foreach(var assetPath in allAssetPaths)
            {
                // assetPathが入稿フォルダ内かチェック
                var submitDirectory = target.GetBaseFolderPath();
                if (!assetPath.StartsWith(submitDirectory))
                {
                    var referenceObject = AssetDatabase.LoadMainAssetAtPath(assetPath);
                    var message = String.Format("アセット{0}が入稿フォルダ内に含まれていません。", assetPath);
                    var solution = String.Format("入稿するアセットは(運営から配布されたアセットを除いて)すべてAssetsフォルダ直下の「出展者ID」フォルダ({0})以下に配置してください。", submitDirectory);
                    AddIssue(new Issue(referenceObject, IssueLevel.Error, message, solution));
                }
            }
        }
    }
}