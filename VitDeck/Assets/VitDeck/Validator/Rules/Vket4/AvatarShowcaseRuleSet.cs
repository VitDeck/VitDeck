using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VitDeck.Validator
{
    public class AvatarShowcaseRuleSet : Vket4RuleSetBase
    {
        public override string RuleSetName
        {
            get
            {
                return "Vket4 - AvatarShowcase";
            }
        }

        protected override int VRCTriggerCountLimit
        {
            get
            {
                return 12;
            }
        }
    }
}