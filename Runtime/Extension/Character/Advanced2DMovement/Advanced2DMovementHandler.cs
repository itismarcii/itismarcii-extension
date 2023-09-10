using System;
using UnityEngine;

namespace itismarciiExtansion.Runtime.Extension.Character.Advanced2DMovement
{
    public static class Advanced2DMovementHandler
    {
        public static void MovementFixedUpdate(ref Advanced2DMovementStruct component, in float deltaTime, in bool isGrounded = false)
        {
            Movement(ref component, isGrounded);

            // Minimum jump height
            component.IsJumpPressed |= component.Transform.position.y - component.StartJumpHeight <= component.Param.MinJumpHeight &&
                              component.Velocity.y > 0 && component.IsJump;

            // Prevent from continuously moving up against ceiling
            if (component.Velocity.y > 0 && Math.Abs(component.Transform.position.y - component.PreviousYPos) < .001f) component.Velocity.y = 0;

            // Apply gravity and prevent jump on contact
            if (!isGrounded) Gravity(ref component, deltaTime);
            else if (!component.IsJumpPressed) component.IsJump = false;
            
            // Prevent increasing gravity velocity
            if (isGrounded) component.Velocity.y = 0;
            
            // Init jump when grounded is called and is not already jumping
            if (isGrounded && component is {IsJump: false, IsJumpPressed: true})
            {
                Jump(ref component, deltaTime);
                component.StartJumpHeight = component.Transform.position.y;
            }
            else if (component is {IsJumpPressed: false, IsJump: true}) 
            {
                // Stop jump upwards
                component.Velocity.y = component.Velocity.y > 0 ? 0 : component.Velocity.y;
                component.IsJump = false;
            } 
            
            Vector2 position = component.Transform.position;
            component.Rgb.MovePosition(position + (component.Velocity * deltaTime));
            component.Transform.localScale = component.Forward;
            component.PreviousYPos = position.y;
        }

        public static void DashFixedUpdate(ref Advanced2DDashStruct component, in float deltaTime)
        {
            if(!component.IsDashing) return;
            
            component.Timer += deltaTime;

            if (component.Timer <component.Param.DashTime)
            {
                component.Rgb.MovePosition(
                    Vector2.Lerp(component.StartPos, component.EndPos, component.Timer / component.Param.DashTime));
            }
            else
            {
                component.Rgb.MovePosition(
                    Vector2.Lerp(component.Rgb.transform.position, component.EndPos, 1));
                
                DashCancel(ref component);
            }
        }

        public static void DashCancel(ref Advanced2DDashStruct component)
        {
            component.IsDashing = false;
            component.OnFinish?.Invoke();
        }

        public static void DashInit(ref Advanced2DDashStruct component)
        {
            if(component.IsDashing) return;
            
            component.IsDashing = true;
            component.Timer = 0;
            component.StartPos = component.Rgb.transform.position;
            component.Forward.x = Mathf.Clamp(component.Transform.localScale.x, -1, 1);
            component.EndPos =  new Vector2(
                component.StartPos.x, 
                component.StartPos.y) + (component.Forward * component.Param.DashDistance);
            component.OnInit?.Invoke();
        }

        public static void MovementUpdate(ref Advanced2DMovementStruct component, in Advanced2DMovementInput input = default)
        {
            component.IsJumpPressed = input.IsJump;
            component.MovementValue = input.Movement;
        }

        private static void Jump(ref Advanced2DMovementStruct component, in float deltaTime)
        {
            component.Velocity.y = component.Param.InitVelocity;
            component.IsJump = true;
        }

        private static void Gravity(ref Advanced2DMovementStruct component, in float deltaTime)
        {
            var param = component.Param;
            component.Velocity.y += (component.Velocity.y > 0 ? param.GravityUp : param.GravityDown);
        }

        private static void Movement(ref Advanced2DMovementStruct component, in bool isGrounded = false)
        {
            var movementValue = component.MovementValue;
            var param = component.Param;
            component.Forward.x = movementValue != 0 ? (int) movementValue : component.Forward.x;

            component.Velocity.x = movementValue * param.MovementSpeed * (isGrounded
                ? param.GroundModifier
                : (component.Velocity.y > 0 ? param.AirModifierUp : param.AirModifierDown));
        }
    }
}
