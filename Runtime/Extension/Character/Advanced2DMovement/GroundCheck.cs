using System;
using UnityEngine;

namespace itismarciiExtansion.Runtime.Extension.Character.Advanced2DMovement

{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField] private Rigidbody _Rgb;
        private PhysicsMaterial2D _StartMaterial;
        public Action<bool> OnGroundCheck;
        
        private void OnTriggerEnter(Collider other)
        {
            var isGrounded = other.CompareTag("Ground");
            OnGroundCheck?.Invoke(isGrounded);
        }

        private void OnTriggerExit(Collider other)
        {
            OnGroundCheck?.Invoke(false);
        }
    }
}