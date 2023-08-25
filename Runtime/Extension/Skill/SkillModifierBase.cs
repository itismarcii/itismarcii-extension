using System;

namespace itismarciiExtansion.Runtime.Skill
{
    public abstract class SkillModifierBase
    {
        protected float Speed = 1;

        public abstract void ApplyModifier(ref SkillBase skill);

        public void RemoveModifier(ref SkillBase skill)
        {
            if(!skill.Param.Modifiers.Contains(this)) return;
            OnRemoveModifier(ref skill);
        }
        
        protected abstract void OnRemoveModifier(ref SkillBase skillBase);
        public abstract bool CheckForCompatibility(in SkillBase skillBase);
    }
}
