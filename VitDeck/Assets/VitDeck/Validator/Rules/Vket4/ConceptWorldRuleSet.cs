using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VitDeck.Validator
{
    public class ConceptWorldRuleSet : Vket4RuleSetBase
    {
        public override string RuleSetName
        {
            get
            {
                return "Vket4 - ConceptWorld";
            }
        }

        protected override int MaterialUsesLimit
        {
            get
            {
                return 20;
            }
        }

        protected override int AreaLightUsesLimit
        {
            get
            {
                return 3;
            }
        }

        protected override LightmapBakeType[] unusablePointLightModes
        {
            get
            {
                return new LightmapBakeType[] { };
            }
        }

        protected override LightmapBakeType[] unusableSpotLightModes
        {
            get
            {
                return new LightmapBakeType[] { };
            }
        }
    }
}