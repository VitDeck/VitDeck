using System;
using VketTools.Utilities;

namespace VitDeck.Validator
{
    internal class DefaultRequestComponent : RequestComponent
    {
        public Type[] Components
        {
            get
            {
                return new Type[0];
            }

            set
            {
            }
        }

        public bool DynamicCollider
        {
            get
            {
                return false;
            }

            set
            {
            }
        }
        public int PickupObjectSync
        {
            get
            {
                return -1;
            }

            set
            {
            }
        }
        public int VrcTrigger
        {
            get
            {
                return -1;
            }

            set
            {
            }
        }
        public bool OriginalPickup
        {
            get
            {
                return false;
            }

            set
            {
            }
        }

        public string[] Propertys
        {
            get
            {
                return new string[0];
            }

            set
            {
            }
        }
    }
}