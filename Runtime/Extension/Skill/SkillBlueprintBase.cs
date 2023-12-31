using System;
using System.Collections.Generic;

namespace itismarciiExtansion.Runtime.Skill
{
    public abstract class SkillBlueprintBase
    {
        protected static SkillBase[] SkillPrefabs;
        
        public string BlueprintPrefabName;
        public Type SkillType { get; private set; }
        public SkillInformationBase Information;
        public List<SkillBlueprintBase> SkillStages = new List<SkillBlueprintBase>();
        public List<SkillModifierBase> Modifiers = new List<SkillModifierBase>();

        public SkillBlueprintBase(in SkillBase skillBase)
        {
            SkillType = skillBase.GetType();
            Information = skillBase.Information;
        }

        public abstract void LoadSkillBasePrefabs();

        public SkillBase GetSkillBase()
        {
            foreach (var skillPrefab in SkillPrefabs)
            {
                if (skillPrefab.GetType() == SkillType) return skillPrefab;
            }

            return null;
        }
        
        public T GetPrefab<T>() where T : SkillBase
        {
            if (typeof(T) != SkillType) return null;
            
            foreach (var skillPrefab in SkillPrefabs)
            {
                if (skillPrefab.GetType() == SkillType) return (T) skillPrefab;
            }

            return null;
        }

        public abstract SkillBase GetPrefab();
        public abstract List<SkillBase> GetSkillStages();
    }
}
