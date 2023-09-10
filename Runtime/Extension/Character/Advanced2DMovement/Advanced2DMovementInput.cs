namespace itismarciiExtansion.Runtime.Extension.Character.Advanced2DMovement
{
    public struct Advanced2DMovementInput
    {
        public float Movement;
        public bool IsJump;
        public bool IsDash;

        public Advanced2DMovementInput(in Advanced2DMovementInput movementInput) : this()
        {
            Movement = movementInput.Movement;
            IsJump = movementInput.IsJump;
            IsDash = movementInput.IsDash;
        }

        public void Reset()
        {
            Movement = 0;
            IsJump = false;
            IsDash = false;
        }
    }
}
