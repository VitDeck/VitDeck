namespace VitDeck.Validator
{
    /// <summary>
    /// サンプルルールセット
    /// </summary>
    public class SampleRuleSet : BaseRuleSet
    {
        public override string RuleSetName
        {
            get { return "サンプルルールセット"; }
        }

        [Validation(order = -1)] public IRule rule1 = new SampleRule("サンプルメッセージ");
        [Validation] public IRule unityVersionRule = new UnityVersionRule("[U01]Unityバージョンルール", "2018.4.20f1");
        [Validation] public IRule assetNamingRule = new AssetNamingRule("[A01]アセット名の使用禁止文字ルール", @"[a-zA-Z0-9 _\.\-]+");

        [Validation] public IRule assetGuidBlacklistRule = new AssetGuidBlacklistRule("[A02]特定のGUIDを持つアセットの検出ルール",
            new string[] { "740112f6e77ca914d9c26eef5d68accd", "ae68339621fb41b4f9905188526120ea" });

        [Validation] public IRule assetPathLengthRule = new AssetPathLengthRule("[A03]アセットパス長制限ルール", 184);

        [Validation] public IRule assetExtentionBlacklistRule =
            new AssetExtentionBlacklistRule("[A04]アセット拡張子ルール", new string[] { ".txt", ".md" });

        [Validation] public IRule boothBoundsRule =
            new BoothBoundsRule("[B01]ブースBounds超過検証ルール", new UnityEngine.Vector3(4.0f, 5.0f, 4.0f), 0.01f);

        [Validation] public IRule componentWhitelistRule = new ComponentWhitelistRule("[B02]コンポーネントホワイトリストルール",
            new ComponentReference[]
            {
                new ComponentReference("ライティング", new string[] { "UnityEngine.Light" }, ValidationLevel.ALLOW),
                new ComponentReference("カメラ", new string[] { "UnityEngine.Camera", "UnityEngine.FlareLayer" },
                    ValidationLevel.ALLOW),
                new ComponentReference("Mesh", new string[] { "UnityEngine.MeshFilter", "UnityEngine.MeshRenderer" },
                    ValidationLevel.ALLOW),
                new ComponentReference("Suport Object", new string[] { "ScaleLimitVisualizer", "NotEditableComponent" },
                    ValidationLevel.ALLOW),
                new ComponentReference("AudioListerner", new string[] { "UnityEngine.AudioListener" },
                    ValidationLevel.DISALLOW)
            });

        [Validation] public IRule componentBlacklistRule = new ComponentBlacklistRule("[B03]コンポーネントブラックリストルール",
            new ComponentReference[]
            {
                new ComponentReference("AudioListerner", new string[] { "UnityEngine.AudioListener" },
                    ValidationLevel.DISALLOW)
            });

        [Validation] public IRule errorShaderRule = new ErrorShaderRule("[B04]エラーシェーダールール");
        [Validation] public IRule noneMeshRule = new NoneMeshRule("[B05]None meshルール");
        [Validation] public IRule missingReferenceRule = new MissingReferenceRule("[B06]missing参照ルール");
        [Validation] public IRule staticFlagRule = new StaticFlagRule("[B07]Staticフラグルール");
    }
}
