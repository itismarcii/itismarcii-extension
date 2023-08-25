using System;
using UnityEngine;

namespace itismarciiExtansion.Runtime.Skill
{
    [Serializable]
    public class SkillInformationBase
    {
        public bool IsPerforming;
        [SerializeField] public float Duration;
        [SerializeField] public float Speed = 1;
    }
}
