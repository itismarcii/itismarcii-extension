using System;
using UnityEngine;

namespace itismarciiExtansion.Runtime.Extension.Character.Advanced2DMovement
{
    [Serializable]
    public struct Advanced2DMovementStruct
    {
        internal Advanced2DMovementParam Param;
        internal Rigidbody2D Rgb;
        internal Transform Transform;
        internal Vector3 Forward;
        public bool IsJump { get; internal set; }
        internal bool IsJumpPressed;
        internal float MovementValue;
        internal Vector2 Velocity;
        internal float PreviousYPos;
        internal float StartJumpHeight;

		public float YVelocity => Velocity.y;

        public Advanced2DMovementStruct(in Rigidbody2D rgb, in Advanced2DMovementParam param)
        {
            Rgb = rgb;
            Rgb.gravityScale = 0;
            Rgb.freezeRotation = true;
            Transform = rgb.transform;
            Param = param;
            Forward = Transform.localScale;
            
            IsJump = false;
            IsJumpPressed = false;
            MovementValue = 0;
            Velocity = default;
            PreviousYPos = 0;
            StartJumpHeight = 0;
        }

        public void Reset() => Velocity = Vector2.zero;
        public void CancelUpVelocity() => Velocity.y = Velocity.y > 0 ? 0 : Velocity.y;
    }
}
