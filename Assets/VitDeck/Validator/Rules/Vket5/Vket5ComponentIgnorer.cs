using System.Collections.Generic;
using UnityEngine;
using VketTools.Utilities;
using VRCSDK2;

namespace VitDeck.Validator
{
    public class Vket5ComponentIgnorer : ICustomComponentIgnorer
    {
        private readonly RequestComponent requestComponent;
        private readonly HashSet<System.Type> customIgnoredTypes;
        public Vket5ComponentIgnorer(RequestComponent requestComponent)
        {
            this.requestComponent = requestComponent;
            this.customIgnoredTypes = new HashSet<System.Type>(requestComponent.Components);
        }

        public bool IsIgnored(Component component)
        {
            if (requestComponent.OriginalPickup)
            {
                if (component is VRC_Pickup)
                {
                    return true;
                }
                else if (component is Rigidbody)
                {
                    if(component.GetComponent<VRC_Pickup>() != null)
                    {
                        return true;
                    }
                }
            }
            return customIgnoredTypes.Contains(component.GetType());
        }
    }
}
