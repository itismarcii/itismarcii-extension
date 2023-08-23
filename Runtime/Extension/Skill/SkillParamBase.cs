using System;
using System.Collections.Generic;
using UnityEngine;

namespace itismarciiExtansion.Runtime.Skill
{
    [Serializable]
    public abstract class SkillParamBase
    {
        internal Type SkillType;
        internal SkillInformationBase Information;
        [SerializeField] internal List<SkillBase> SkillStages;
        internal List<SkillModifierBase> Modifiers;

        public SkillParamBase(in SkillBlueprintBase blueprint)
        {
            SkillType = blueprint.SkillType;
            Information = blueprint.Information;
            SkillStages = blueprint.GetSkillStages();
            Modifiers = blueprint.Modifiers;
        }
    }
}
