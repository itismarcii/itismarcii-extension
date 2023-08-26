using UnityEngine;

namespace itismarciiExtansion.Runtime.StateMachine.Mono
{
    public abstract class SubMachineMono
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
        
        public void Update()
        {
            CurrentState.Update();
            OnUpdateState();
        }

        public void FixedUpdate()
        {
            CurrentState.FixeUpdate();
            OnFixedUpdateState();
        }
        
        public void OnCollisionEnter(Collision other)
        {
            CurrentState.OnCollisionEnter(other);
            OnCollisionEnterState(other);
        }

        public void OnCollisionStay(Collision other)
        {
            CurrentState.OnCollisionStay(other);
            OnCollisionStayState(other);
        }

        public void OnCollisionExit(Collision other)
        {
            CurrentState.OnCollisionExit(other);
            OnCollisionExitState(other);
        }

        public void OnTriggerEnter(Collider other)
        {
            CurrentState.OnTriggerEnter(other);
            OnTriggerEnterState(other);
        }

        public void OnTriggerStay(Collider other)
        {
            CurrentState.OnTriggerStay(other);
            OnTriggerStayState(other);
        }

        public void OnTriggerExit(Collider other)
        {
            CurrentState.OnTriggerExit(other);
            OnTriggerExitState(other);
        }
        
        public virtual void OnEnterState() {}
        public virtual void OnUpdateState() {}
        public virtual void OnFixedUpdateState() {}
        public virtual void OnCollisionEnterState(in Collision other) {}
        public virtual void OnCollisionStayState(in Collision other) {}
        public virtual void OnCollisionExitState(in Collision other) {}
        public virtual void OnTriggerEnterState(in Collider other) {}
        public virtual void OnTriggerStayState(in Collider other) {}
        public virtual void OnTriggerExitState(in Collider other) {}
        public virtual void OnExitState() {}
    }
}
