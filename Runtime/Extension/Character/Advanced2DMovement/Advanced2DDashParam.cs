using System;
using UnityEngine;

namespace itismarciiExtansion.Runtime.Extension.Character.Advanced2DMovement
{
    [CreateAssetMenu(menuName = "Advanced2DMovement/Param/DashParam", fileName = "New DashParam")]
    public class Advanced2DDashParam : ScriptableObject
    {
        [SerializeField] private float _CooldownTime = .8f;
        [SerializeField] private float _DashDistance = 6f;
        [SerializeField] private float _DashTime = .13f;
        
        public float DashDistance
        {
            get => _DashDistance;
            private set => _DashDistance = value;
        }

        public float DashTime
        {
            get => _DashTime;
            private set => _DashTime = value;
        }

        public float CooldownTime
        {
            get => _CooldownTime;
            private set => _CooldownTime = value;
        }
    }
}