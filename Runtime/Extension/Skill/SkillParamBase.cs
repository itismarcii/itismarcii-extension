using System;
using System.Collections.Generic;
using UnityEngine;

namespace itismarciiExtansion.Runtime.Skill
{
    [Serializable]
    public abstract class SkillParamBase
    {
        public Type SkillType;
        public SkillInformationBase Information;
        [SerializeField] public List<SkillBase> SkillStages;
        public List<SkillModifierBase> Modifiers;

        public SkillParamBase(in SkillBlueprintBase blueprint)
        {
            SkillType = blueprint.SkillType;
            Information = blueprint.Information;
            SkillStages = blueprint.GetSkillStages();
            Modifiers = blueprint.Modifiers;
        }
    }
}
