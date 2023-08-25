using UnityEngine;

namespace itismarciiExtansion.Runtime.StateMachine.Mono
{
    public abstract class StateMachineMono : MonoBehaviour
    {
        public StateMono CurrentState { get; private set; }

        public virtual void Init(in StateMono idleState)
        {
            CurrentState = idleState;
            if(CurrentState.Enter(this)) OnEnterState();
        }

        public bool EnterState(in StateMono state)
        {
            if (!state.Enter(this)) return false;
            CurrentState = state;
            OnEnterState();
            return true;
        }

        private void Update()
        {
            CurrentState.Update();
            OnUpdateState();
        }

        private void FixedUpdate()
        {
            CurrentState.FixeUpdate();
            OnFixedUpdateState();
        }

        private void OnCollisionEnter(Collision other)
        {
            CurrentState.OnCollisionEnter(other);
            OnCollisionEnterState(other);
        }

        private void OnCollisionStay(Collision other)
        {
            CurrentState.OnCollisionStay(other);
            OnCollisionStayState(other);
        }

        private void OnCollisionExit(Collision other)
        {
            CurrentState.OnCollisionExit(other);
            OnCollisionExitState(other);
        }

        private void OnTriggerEnter(Collider other)
        {
            CurrentState.OnTriggerEnter(other);
            OnTriggerEnterState(other);
        }

        private void OnTriggerStay(Collider other)
        {
            CurrentState.OnTriggerStay(other);
            OnTriggerStayState(other);
        }

        private void OnTriggerExit(Collider other)
        {
            CurrentState.OnTriggerExit(other);
            OnTriggerExitState(other);
        }

        protected virtual void OnEnterState() {}
        protected virtual void OnUpdateState() {}
        protected virtual void OnFixedUpdateState() {}
        protected virtual void OnCollisionEnterState(in Collision other) {}
        protected virtual void OnCollisionStayState(in Collision other) {}
        protected virtual void OnCollisionExitState(in Collision other) {}
        protected virtual void OnTriggerEnterState(in Collider other) {}
        protected virtual void OnTriggerStayState(in Collider other) {}
        protected virtual void OnTriggerExitState(in Collider other) {}
        public virtual void OnExitState() {}
    }
}
