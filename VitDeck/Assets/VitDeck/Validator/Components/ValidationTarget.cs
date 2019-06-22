using UnityEngine;
using UnityEngine.SceneManagement;

namespace VitDeck.Validator
{
    /// <summary>
    /// 検証対象オブジェクトを格納したコンテナクラス
    /// </summary>
    /// <remarks>設定されていない対象を取得しようとした場合は`FatalValidationErrorException`を発生させる。</remarks>
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
        /// <param name="baseFolderPath">ベースフォルダのパス</param>
        /// <param name="assetGuids">ベースフォルダ内の全てのアセットファイルのGUID</param>
        /// <param name="assetPaths">ベースフォルダ内の全てのアセットファイルのパス</param>
        /// <param name="assetObjects">ベースフォルダ内の全てのアセットオブジェクト</param>
        /// <param name="scenes">検証対象のシーン</param>
        /// <param name="rootObjects">検証対象のルートオブジェクト</param>
        /// <param name="allObjects">検証対象の全てのオブジェクト</param>
        public ValidationTarget(string baseFolderPath,
                                string[] assetGuids = null,
                                string[] assetPaths = null,
                                UnityEngine.Object[] assetObjects = null,
                                Scene[] scenes = null,
                                GameObject[] rootObjects = null,
                                GameObject[] allObjects = null)
        {
            this.baseFolderPath = baseFolderPath;
            this.assetGuids = assetGuids;
            this.assetPaths = assetPaths;
            this.assetObjects = assetObjects;
            this.scenes = scenes;
            this.rootObjects = rootObjects;
            this.allObjects = allObjects;
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
            if (scenes == null)
                throw new FatalValidationErrorException("Faild to get scenes.");
            return scenes;
        }
        /// <summary>
        /// 検証対象の全てのルートオブジェクトを取得する
        /// </summary
        /// <returns> 検証対象の全てのルートオブジェクト</returns>
        public GameObject[] GetRootObjects()
        {
            if (rootObjects == null)
                throw new FatalValidationErrorException("Faild to get root objects.");
            return rootObjects;
        }
        /// <summary>
        /// ルートオブジェクト以下の全てのGameObjectを取得する
        /// </summary>
        /// <returns>検証対象の全てのGameObject</returns>
        public GameObject[] GetAllObjects()
        {
            if (allObjects == null)
                throw new FatalValidationErrorException("Faild to get all objects.");
            return allObjects;

        }
        /// <summary>
        /// 検証対象の全てのアセットのGUIDを取得する
        /// </summary>
        /// <returns>全てのアセットのGUID</returns>
        public string[] GetAllAssetGuids()
        {
            if (assetGuids == null)
                throw new FatalValidationErrorException("Faild to get asset GUIDs.");
            return assetGuids;
        }
        /// <summary>
        /// 検証対象の全てのアセットのパスを取得する
        /// </summary>
        /// <returns>検証対象の全てのアセットのパス</returns>
        public string[] GetAllAssetPaths()
        {
            if (assetPaths == null)
                throw new FatalValidationErrorException("Faild to get asset Paths.");
            return assetPaths;
        }
        /// <summary>
        /// 検証対象の全てのアセットのオブジェクト
        /// </summary>
        /// <returns>全てのアセットのオブジェクト</returns>
        public UnityEngine.Object[] GetAllAssets()
        {
            if (assetObjects == null)
                throw new FatalValidationErrorException("Faild to get asset Objects.");
            return assetObjects;
        }
    }
}