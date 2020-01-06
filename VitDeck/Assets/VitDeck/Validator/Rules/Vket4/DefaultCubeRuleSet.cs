using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VitDeck.Validator
{
    public class DefaultCubeRuleSet : Vket4RuleSetBase
    {
        public override string RuleSetName
        {
            get
            {
                return "Vket4 - DefaultCube";
            }
        }

        protected override int MaterialUsesLimit
        {
            get
            {
                return 60;
            }
        }

        protected override int AreaLightUsesLimit
        {
            get
            {
                return 3;
            }
        }
    }
}