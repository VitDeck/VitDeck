using System;

namespace VitDeck.Validator
{
    /// <summary>
    /// 検証ルールであることを示すカスタム属性
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class ValidationAttribute : System.Attribute, IComparable<ValidationAttribute>
    {
        /// <summary>
        /// ルールの実行順序。値が小さいほど先に実行される。
        /// </summary>
        public int order = 0;
        public int CompareTo(ValidationAttribute item)
        {
            return this.order - item.order;
        }
    }
}