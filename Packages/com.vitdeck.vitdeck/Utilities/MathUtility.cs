using System;

namespace VitDeck.Utilities
{
    /// <summary>
    /// 計算・表記周りの機能を提供するクラス。
    /// </summary>
    public static class MathUtility
    {
        /// <summary>
        /// 容量をMiB表記で返します。
        /// </summary>
        /// <param name="byteCount"></param>
        /// <returns></returns>
        public static string FormatByteCount(int byteCount)
        {
            return (byteCount / Math.Pow(2, 20)).ToString("0.00' MiB'");
        }
    }
}
