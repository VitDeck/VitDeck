namespace VitDeck.Validator
{
    /// <summary>
    /// 検証ルールが持つべきインターフェース
    /// </summary>
    public interface IRule
    {
        ValidationResult Validate();
        ValidationResult GetResult();
    }
}