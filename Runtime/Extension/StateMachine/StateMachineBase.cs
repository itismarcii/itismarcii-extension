namespace itismarciiExtansion.Runtime.StateMachine
{
    public abstract class StateMachineBase
    {
        public StateBase CurrentState { get; internal set; }
        
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
        public virtual void OnExitState() {}

    }
}
