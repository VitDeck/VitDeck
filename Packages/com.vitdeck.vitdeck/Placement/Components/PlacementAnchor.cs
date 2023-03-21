using UnityEngine;

namespace VitDeck.Placement.Components
{
    /// <summary>
    /// 配置先のGameObjectへ設定するコンポーネント。
    /// </summary>
    /// <remarks>
    /// 初期状態で子は空、もしくはダミーオブジェクト。
    /// 配置後は数字の出展者IDが名前となっているGameObjectが、直下に1つだけ存在。
    /// 配置時にダミーオブジェクトはすべて削除されます。
    /// </remarks>
    public class PlacementAnchor : MonoBehaviour
    {
    }
}
