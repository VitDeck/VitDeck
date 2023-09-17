namespace VitDeck.Utilities
{
    public class ProductSettings
    {
        /// <summary>
        /// スクリプティング定義のシンボルに「VITDECK_HIDE_MENUITEM」が存在していれば (「Info」以外のメニューアイテムが非表示なら) <c>true</c>。
        /// </summary>
        public static readonly bool HideMenuItem =
#if VITDECK_HIDE_MENUITEM
            true
#else
                false
#endif
            ;
    }
}
