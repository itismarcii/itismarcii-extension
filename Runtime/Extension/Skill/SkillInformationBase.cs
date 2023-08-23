using System;
using UnityEngine;

namespace itismarciiExtansion.Runtime.Skill
{
    [Serializable]
    public class SkillInformationBase
    {
        internal bool IsPerforming;
        [SerializeField] internal float Duration;
        [SerializeField] internal float Speed = 1;
    }
}
