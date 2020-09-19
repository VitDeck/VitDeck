namespace VketTools.Utilities
{
    public interface RequestComponent
    {
        System.Type[] Components { get; set; } /* 許可コンポーネント */
        string[] Propertys { get; set; } /* 許可プロパティ（「コンポーネント.プロパティ」の形式） */
        bool DynamicCollider { get; set; } /* Animationで動くコライダーの許可 */
        int PickupObjectSync { get; set; } /* Pickupプレハブの上限値変更 */
        int VrcTrigger { get; set; } /* VRC_Triggerの上限値変更 */
        bool OriginalPickup { get; set; } /* Pickupプレハブ以外のPickupの許可 */
    }
}