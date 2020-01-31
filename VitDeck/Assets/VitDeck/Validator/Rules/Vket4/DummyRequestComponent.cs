using System;
using VketTools.Utilities;

namespace VitDeck.Validator
{
    internal class DummyRequestComponent : RequestComponent
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
                return true;
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
                return true;
            }

            set
            {
            }
        }

        public string[] Propertys
        {
            get
            {
                return new string[] { };
            }

            set
            {
            }
        }
    }
}