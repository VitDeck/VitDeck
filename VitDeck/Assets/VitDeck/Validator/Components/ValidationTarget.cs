using UnityEngine;
using UnityEngine.SceneManagement;

namespace VitDeck.Validator
{
    /// <summary>
    /// 検証対象オブジェクトを格納したコンテナクラス
    /// </summary>
    public class ValidationTarget
    {
        private readonly string baseFolderPath;
        private readonly Scene[] scenes;
        private readonly GameObject[] rootObjects;
        private readonly GameObject[] allObjects;
        private readonly string[] assetGuids;
        private readonly string[] assetPaths;
        private readonly UnityEngine.Object[] assetObjects;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="baseFolderPath">`Asset`から始まる検証対象のベースフォルダのパス</param>
        public ValidationTarget(string baseFolderPath)
        {
            this.baseFolderPath = baseFolderPath;
            //ToDo:各種対象の詰め込み
        }

        /// <summary>
        /// ベースフォルダのパスを取得する
        /// </summary>
        /// <returns>ベースフォルダのパス</returns>
        public string GetBaseFolderPath()
        {
            return baseFolderPath;
        }
        /// <summary>
        /// 検証対象の全てのシーンファイルを取得する
        /// </summary>
        /// <returns>検証対象の全てのシーンファイル</returns>
        public Scene[] GetScenes()
        {
            return scenes;
        }
        /// <summary>
        /// 検証対象の全てのルートオブジェクトを取得する
        /// </summary
        /// <returns> 検証対象の全てのルートオブジェクト</returns>
        public GameObject[] GetRootObjects()
        {
            return rootObjects;
        }
        /// <summary>
        /// ルートオブジェクト以下の全てのGameObjectを取得する
        /// </summary>
        /// <returns>検証対象の全てのGameObject</returns>
        public GameObject[] GetAllObjects()
        {
            return allObjects;

        }
        /// <summary>
        /// 検証対象の全てのアセットのGUIDを取得する
        /// </summary>
        /// <returns>全てのアセットのGUID</returns>
        public string[] GetAllAssetGuids()
        {
            return assetGuids;
        }
        /// <summary>
        /// 検証対象の全てのアセットのパスを取得する
        /// </summary>
        /// <returns>検証対象の全てのアセットのパス</returns>
        public string[] GetAllAssetPaths()
        {
            return assetPaths;
        }
        /// <summary>
        /// 検証対象の全てのアセットのオブジェクト
        /// </summary>
        /// <returns>全てのアセットのオブジェクト</returns>
        public UnityEngine.Object[] GetAllAssets()
        {
            return assetObjects;
        }
    }
}