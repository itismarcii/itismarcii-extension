using System;
using System.Collections;
using UnityEngine;

namespace itismarciiExtansion.Runtime.Skill
{
    public abstract class SkillBase : MonoBehaviour
    {
        internal SkillParamBase Param;
        public SkillInformationBase Information { get; private set; }
        protected Transform Transform;
        internal Action OnActivation, OnDeactivation, OnSetupBase, OnDisableSkill, OnForceStop;
        protected bool IsSetupBase;

        protected float SkillTime { get; private set; } = 0;
        public float Duration { get; protected set; } = 0;

        protected bool IsForcedStop { get; private set; } = false;

        internal virtual void SetupBase()
        {
            SetupParam();
            Transform = transform;

            foreach (var skillStage in Param.SkillStages)
            {
                skillStage.SetupBase();
            }

            IsSetupBase = true;
            OnSetupBase?.Invoke();
        }

        protected void ExecuteFixedUpdate(in float deltaTime)
        {
            SkillTime += deltaTime * Param.Information.Speed;

            if (SkillTime < Param.Information.Duration)
            {
                PerformFixedUpdateTime(deltaTime);
                PerformFixedUpdatePercentage(SkillTime / Param.Information.Duration);
            }
            else
            {
                LastFixedUpdateTime(deltaTime);
                LastFixedUpdatePercentage(1.0f);
                if(SkillTime >= Duration) Deactivate();
            }
        }
        
        internal virtual void PerformFixedUpdateTime(in float deltaTime) {}
        internal virtual void PerformFixedUpdatePercentage(in float percentage) { }
        internal virtual void LastFixedUpdateTime(in float deltaTime) { }
        internal virtual void LastFixedUpdatePercentage(in float percentage) { }

        protected abstract void SetupParam();
        
        internal virtual void Activate()
        {
            if(Param.Information.Speed <= 0 || !IsSetupBase) return;
            
            IsForcedStop = false;
            SkillTime = 0;
            gameObject.SetActive(true);
            BeforeActivation();
            OnActivation?.Invoke();
        }

        protected virtual void BeforeActivation() {}
        
        internal virtual void Deactivate()
        {
            StartCoroutine(InitSkillStages());
            OnDeactivation?.Invoke();
        }

        protected IEnumerator InitSkillStages()
        {
            if(!IsSetupBase) yield break;
            
            yield return new WaitForEndOfFrame();

            if (IsForcedStop)
            {
                IsForcedStop = false;
                yield break;
            }

            foreach (var skillStage in Param.SkillStages)
            {
                skillStage.ActivateSkill();
            }
            
            DisableSkill();
        }

        protected abstract void ActivateSkill();

        internal void DisableSkill()
        {
            OnDisableSkill?.Invoke();
            gameObject.SetActive(false);
        }

        internal void ForceStop()
        {
            IsForcedStop = true;
            OnForceStop?.Invoke();
            DisableSkill();
        }
    }
}
