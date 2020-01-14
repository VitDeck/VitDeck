using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VitDeck.Validator
{
    public class ConceptWorldDoubleRuleSet : ConceptWorldRuleSet
    {
        public override string RuleSetName
        {
            get
            {
                return "Vket4 - ConceptWorld(Double)";
            }
        }

        protected override Vector3 BoothSizeLimit
        {
            get
            {
                return new Vector3(8, 5, 4);
            }
        }

        protected override int MaterialUsesLimit
        {
            get
            {
                return base.MaterialUsesLimit * 2;
            }
        }

        protected override int LightmapCountLimit
        {
            get
            {
                return base.LightmapCountLimit * 2;
            }
        }
        protected override int AreaLightUsesLimit
        {
            get
            {
                return base.AreaLightUsesLimit * 2;
            }
        }

        protected override int ChairPrefabUsesLimit
        {
            get
            {
                return base.ChairPrefabUsesLimit * 2;
            }
        }

        protected override int PickupObjectSyncUsesLimit
        {
            get
            {
                return base.PickupObjectSyncUsesLimit * 2;
            }
        }
    }
}