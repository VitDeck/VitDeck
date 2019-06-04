namespace VitDeck.Validator
{
    /// <summary>
    /// 検証ルールであることを示すカスタム属性
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field)]
    internal class ValidationAttribute : System.Attribute
    {
    }
}