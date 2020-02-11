using System;
using UnityEditor;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using VitDeck.Language;

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

            // 入稿フォルダ内に配置されているファイルのパス
            // GetFilesで取得したパス名にはバックスラッシュが混在するためスラッシュに変換
            var filePathsInSubmitDirectory = Directory
                .GetFiles(submitDirectory, "*", SearchOption.AllDirectories)
                .Select(x => x.Replace("\\", "/"));
            
            // 入稿フォルダ内のディレクトリのパス
            var folderPathInSubmitDirectory = Directory
                .GetDirectories(submitDirectory, "*", SearchOption.AllDirectories)
                .Select(x => x.Replace("\\", "/"));

            foreach (var assetPath in allAssetPaths)
            {
                // 運営からの配布物を検証対象から除外
                if (excludePaths.Contains(assetPath))
                    continue;

                // 入稿フォルダ内のサブディレクトリ(アセット含まない)を検証対象から除外
                if (folderPathInSubmitDirectory.Contains(assetPath) || assetPath == submitDirectory)
                    continue;

                // 入稿フォルダ内にパスがあるアセットなのか検証
                if (!filePathsInSubmitDirectory.Contains(assetPath))
                {
                    var referenceObject = AssetDatabase.LoadMainAssetAtPath(assetPath);
                    var message = LocalizedMessage.Get("A04_ExistInSubmitFolderRule.AssetOutOfPackage", assetPath);
                    var solution = LocalizedMessage.Get("A04_ExistInSubmitFolderRule.AssetOutOfPackage.Solution");
                    AddIssue(new Issue(referenceObject, IssueLevel.Error, message, solution));
                }
            }
        }
    }
}