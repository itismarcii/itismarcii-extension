using itismarciiExtansion.Runtime.Extension.Character.Advanced2DMovement;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Advanced2DMovementParam MovementParam;
    [SerializeField] private Advanced2DDashParam DashParam;
    [SerializeField] private Rigidbody2D Rgb;
    [SerializeField] private GroundCheck2D _GroundCheck2D;
    private Advanced2DMovementStruct Movement;
    private Advanced2DDashStruct Dash;

    private bool _IsGrounded = false;
    
    private void Awake()
    {
        _GroundCheck2D.OnGroundCheck += (isGrounded) => _IsGrounded = isGrounded;
        Movement = new Advanced2DMovementStruct(Rgb, MovementParam);
        Dash = new Advanced2DDashStruct(Rgb, DashParam);
    }

    private void Update()
    {
        var input = new Advanced2DMovementInput()
        {
            Movement = Input.GetAxisRaw("Horizontal"),
            IsJump = Input.GetKey(KeyCode.Space),
            IsDash = Input.GetKeyDown(KeyCode.LeftShift)
        };
        
        Advanced2DMovementHandler.MovementUpdate(ref Movement, input); 
        if(input.IsDash) Advanced2DMovementHandler.DashInit(ref Dash);
    }

    private void FixedUpdate()
    {
        Advanced2DMovementHandler.MovementFixedUpdate(ref Movement, Time.fixedDeltaTime, _IsGrounded);
        Advanced2DMovementHandler.DashFixedUpdate(ref Dash, Time.fixedDeltaTime);
    }
}
