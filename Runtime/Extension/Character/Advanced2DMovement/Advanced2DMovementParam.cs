using System;
using UnityEngine;

namespace itismarciiExtansion.Runtime.Extension.Character.Advanced2DMovement
{
    [CreateAssetMenu(menuName = "Advanced2DMovement/Param/MovementParam", fileName = "New MovementParam")]
    public class Advanced2DMovementParam : ScriptableObject
    {
        [SerializeField,Range(1f, 25f) ] private float _MovementSpeed = 10f;
        [SerializeField,Range(0.1f, 2f) ] private float _MovementAirModifierUp = 1.6f;
        [SerializeField,Range(0.1f, 2f) ] private float _MovementAirModifierDown = .9f;
        [SerializeField,Range(0.1f, 2f) ] private float _MovementGroundModifier = 1f;
        [SerializeField,Range(.01f, 12f) ] private float _MaxJumpHeight = 8.94f;
        [SerializeField,Range(.01f, 4f) ] private float _MinJumpHeight = 3.14f;
        [SerializeField,Range(.01f, 3f) ] private float _JumpTimeUp = .5f;
        [SerializeField,Range(.01f, 3f) ] private float _JumpTimeDown = .38f;
        public float InitVelocity { get; private set; }
        public float GravityDown { get; private set; }
        public float GravityUp { get; private set; }

        public float MinJumpHeight => _MinJumpHeight;
        public float MovementSpeed => _MovementSpeed;
        public float GroundModifier => _MovementGroundModifier;
        public float AirModifierUp => _MovementAirModifierUp;
        public float AirModifierDown => _MovementAirModifierDown;

        private void OnEnable()
        {
            Setup(Time.fixedDeltaTime);
        }

        public void Setup(in float deltaTime)
        {
            GravityUp = (-2f * _MaxJumpHeight) / Mathf.Pow(_JumpTimeUp, 2) * deltaTime;
            GravityDown = (-2f * _MaxJumpHeight) / Mathf.Pow(_JumpTimeDown, 2) * deltaTime;
            InitVelocity = (2 * _MaxJumpHeight) / _JumpTimeUp;
        }
    }
}