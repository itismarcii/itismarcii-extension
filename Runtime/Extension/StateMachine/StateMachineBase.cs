namespace itismarciiExtansion.Runtime.StateMachine
{
    public abstract class StateMachineBase
    {
        internal StateBase CurrentState { get; private set; }
        
        public virtual void Init(in StateBase idleState)
        {
            CurrentState = idleState;
            if(CurrentState.Enter(this)) OnEnterState();
        }
        
        public void EnterState(in StateBase state)
        {
            if (!state.Enter(this)) return;
            CurrentState = state;
            OnEnterState();
        }
        
        protected virtual void OnEnterState() {}
        internal virtual void OnExitState() {}

    }
}
