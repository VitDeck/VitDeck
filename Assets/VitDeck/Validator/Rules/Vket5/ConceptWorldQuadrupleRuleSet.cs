using UnityEngine;

namespace VitDeck.Validator
{
    public class ConceptWorldQuadrupleRuleSet : ConceptWorldRuleSet
    {
        public override string RuleSetName
        {
            get
            {
                return "Vket5 - ConceptWorld(Quadruple)";
            }
        }

        protected override long FolderSizeLimit
        {
            get
            {
                return base.FolderSizeLimit * 4;
            }
        }

        protected override Vector3 BoothSizeLimit
        {
            get
            {
                return new Vector3(16, 5, 4);
            }
        }

        protected override int MaterialUsesLimit
        {
            get
            {
                return base.MaterialUsesLimit * 4;
            }
        }

        protected override int LightmapCountLimit
        {
            get
            {
                return base.LightmapCountLimit * 4;
            }
        }
        protected override int AreaLightUsesLimit
        {
            get
            {
                return base.AreaLightUsesLimit * 4;
            }
        }

        protected override int ChairPrefabUsesLimit
        {
            get
            {
                return base.ChairPrefabUsesLimit * 4;
            }
        }

        protected override int PickupObjectSyncUsesLimit
        {
            get
            {
                return base.PickupObjectSyncUsesLimit * 4;
            }
        }
    }
}