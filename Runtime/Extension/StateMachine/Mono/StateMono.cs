using UnityEngine;

namespace itismarciiExtansion.Runtime.StateMachine.Mono
{
    public abstract class StateMono
    {
        private SubMachineMono _SubMachineMono;
        protected bool _HasSubMachine = false;

        public SubMachineMono SubMachine
        {
            get => _SubMachineMono;
            protected set
            {
                _HasSubMachine = value != null;
                _SubMachineMono = value;
            }
        }
        
        internal bool Enter(in StateMachineMono stateMachine)
        {
            if(!CanChangeTo(stateMachine.CurrentState)) return false;
            stateMachine.CurrentState.Exit();
            stateMachine.OnExitState();
            return true;
        }
        
        internal bool Enter(in SubMachineMono stateMachine)
        {
            if(!CanChangeTo(stateMachine.CurrentState)) return false;
            stateMachine.CurrentState.Exit();
            stateMachine.OnExitState();
            return true;
        }
        
        internal abstract void OnEnter(in StateMachineMono stateMachine = null);
        internal abstract void OnEnter(in SubMachineMono stateMachine = null);
        public abstract void Update(in StateMachineMono stateMachine = null);
        public abstract void FixeUpdate(in StateMachineMono stateMachine = null);
        public virtual void OnCollisionEnter(in Collision other, in StateMachineMono stateMachine = null) {}
        public virtual void OnCollisionStay(in Collision other, in StateMachineMono stateMachine = null) {}
        public virtual void OnCollisionExit(in Collision other, in StateMachineMono stateMachine = null) {}
        public virtual void OnTriggerEnter(in Collider other, in StateMachineMono stateMachine = null) {}
        public virtual void OnTriggerStay(in Collider other, in StateMachineMono stateMachine = null) {}
        public virtual void OnTriggerExit(in Collider other, in StateMachineMono stateMachine = null) {}
        protected abstract void Exit(in StateMachineMono stateMachine = null);
        protected abstract bool CanChangeTo(in StateMono state);
    }
}
