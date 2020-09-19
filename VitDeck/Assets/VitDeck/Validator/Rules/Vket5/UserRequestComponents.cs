namespace VketTools.Utilities
{
    public class UserRequestComponents : RequestComponent
    {
        public System.Type[] Components { get; set; }
        public string[] Propertys { get; set; }
        public bool DynamicCollider { get; set; }
        public int PickupObjectSync { get; set; }
        public int VrcTrigger { get; set; }
        public bool OriginalPickup { get; set; }
    }
}