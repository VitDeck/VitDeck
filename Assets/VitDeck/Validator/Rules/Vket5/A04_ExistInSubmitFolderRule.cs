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
        private readonly Vket5TargetFinder targetFinder;
        public A04_ExistInSubmitFolderRule(string name, string[] guids, Vket5TargetFinder targetFinder) : base(name)
        {
            unauthorizedIDSet = new HashSet<string>(guids);
            this.targetFinder = targetFinder;
        }

        protected override void Logic(ValidationTarget target)
        {
            var referenceDictionary = targetFinder.ReferenceDictionary;
            
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
                // Unityのビルトインアセットを除外
                if(!assetPath.StartsWith("Assets"))
                    continue;

                // 運営からの配布物を検証対象から除外
                if (excludePaths.Contains(assetPath))
                    continue;

                // 入稿フォルダ内のサブディレクトリ(アセット含まない)を検証対象から除外
                if (folderPathInSubmitDirectory.Contains(assetPath) || assetPath == submitDirectory)
                    continue;

                // 入稿フォルダ内にパスがあるアセットなのか検証
                if (filePathsInSubmitDirectory.Contains(assetPath)) 
                    continue;
                
                // エラー対象である事が確定したためIssue発行
                var targetAsset = AssetDatabase.LoadMainAssetAtPath(assetPath);
                referenceDictionary.Reverse.TryGetValue(targetAsset, out var referrerAssets);

                var referrerMessage = 
                    LocalizedMessage.Get("A04_ExistInSubmitFolderRule.HasOutOfPackageReference", assetPath);
                var referrerSolution =
                    LocalizedMessage.Get("A04_ExistInSubmitFolderRule.HasOutOfPackageReference.Solution");
                var referrerSolutionURL =
                    LocalizedMessage.Get("A04_ExistInSubmitFolderRule.HasOutOfPackageReference.SolutionURL");

                if (referrerAssets != null)
                {
                    foreach (var referrerAsset in referrerAssets)
                    {
                        AddIssue(new Issue(referrerAsset, IssueLevel.Error, referrerMessage, referrerSolution, referrerSolutionURL));
                    }
                }
                
                var message = LocalizedMessage.Get("A04_ExistInSubmitFolderRule.AssetOutOfPackage", assetPath);
                var solution = LocalizedMessage.Get("A04_ExistInSubmitFolderRule.AssetOutOfPackage.Solution");

                AddIssue(new Issue(targetAsset, IssueLevel.Error, message, solution));
            }
        }
    }
}