using System;
using UnityEngine;

namespace itismarciiExtansion.Runtime.Extension.Character.Advanced2DMovement
{
    public class GroundCheck2D : MonoBehaviour
    {
        [SerializeField] private Collider2D _Collider2D;
        [SerializeField] private Rigidbody2D _Rgb;
        private PhysicsMaterial2D _StartMaterial;
        public Action<bool> OnGroundCheck;

        private void Awake()
        {
            _StartMaterial = _Rgb.sharedMaterial;
            _Collider2D.isTrigger = true;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var isGrounded = other.CompareTag("Ground");
            OnGroundCheck?.Invoke(isGrounded);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _Rgb.sharedMaterial = _StartMaterial;
            OnGroundCheck?.Invoke(false);
        }
    }
}
