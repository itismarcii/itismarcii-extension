using UnityEngine;

namespace itismarciiExtansion.Runtime.Extension.Character
{
    public static class MovementHandler
    {
        public static float Gravity { get; private set; } = 9.81f;

        public static void SetGravity(in float gravity) => Gravity = gravity;

        public static void MoveHorizontal(ref Vector3 endPosition, in float axisValue, in float speed,
            in float deltaTime) => endPosition += Vector3.right * (axisValue * deltaTime * speed);
        
        public static void MoveHorizontal(ref Vector3 endPosition, in float speed, in float deltaTime) => 
            endPosition += Vector3.right * deltaTime * speed;

        public static void MoveHorizontal(in CharacterController controller, in float axisValue, in float speed,
            in float deltaTime) => controller.Move(Vector3.right * axisValue * deltaTime * speed);
        
        public static void MoveHorizontal(in CharacterController controller, in float speed, in float deltaTime) => 
            controller.Move(Vector3.right * deltaTime * speed);
        
        public static void MoveVertical(ref Vector3 endPosition, in float axisValue, in float speed,
            in float deltaTime) => endPosition += Vector3.forward * (axisValue * deltaTime * speed);
        
        public static void MoveVertical(ref Vector3 endPosition, in float speed, in float deltaTime) => 
            endPosition += Vector3.forward * deltaTime * speed;
        
        public static void MoveVertical(in CharacterController controller, in float axisValue, in float speed,
            in float deltaTime) => controller.Move(Vector3.forward * axisValue * deltaTime * speed);
        
        public static void MoveVertical(in CharacterController controller, in float speed, in float deltaTime) =>
            controller.Move(Vector3.forward * deltaTime * speed);
        
        public static void MoveUp(ref Vector3 endPosition, in float axisValue, in float speed, in float deltaTime) => 
            endPosition += Vector3.up * (axisValue * deltaTime * speed);
        
        public static void MoveUp(ref Vector3 endPosition, in float speed, in float deltaTime) => 
            endPosition += Vector3.up * deltaTime * speed;
        
        public static void MoveUp(in CharacterController controller, in float axisValue, in float speed,
            in float deltaTime) => controller.Move(Vector3.up * axisValue * deltaTime * speed);
        
        public static void MoveUp(in CharacterController controller, in float speed, in float deltaTime) => 
            controller.Move(Vector3.up * deltaTime * speed);

        public static void MoveHorizontal(ref Vector3 endPosition, in Vector3 forward, in float speed,
            in float deltaTime) => endPosition += forward * deltaTime * speed;
        
        public static void MoveHorizontal(in CharacterController controller, in Vector3 forward, in float speed,
            in float deltaTime) => controller.Move(forward * deltaTime * speed);

        public static void AutoRotate(in Transform objTransform, in Vector3 position) => objTransform.LookAt(position);

        public static void ApplyGravity(ref Vector3 endPosition, in float deltaTime) =>
            endPosition += Vector3.down * Gravity * deltaTime;
        
        public static void ApplyGravity(in CharacterController controller, in float deltaTime) => 
            controller.Move(Vector3.down * Gravity * deltaTime);
        
    }
}
