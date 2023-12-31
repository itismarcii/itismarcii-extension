namespace itismarciiExtansion.Runtime.StateMachine
{
    public abstract class StateBase
    {
        public bool Enter(in StateMachineBase stateMachine)
        {
            if(!CanChangeTo(stateMachine.CurrentState)) return false;
            stateMachine.CurrentState.Exit();
            stateMachine.OnExitState();
            stateMachine.CurrentState = this;
            OnEnter(stateMachine);
            return true;
        }
        
        protected abstract void OnEnter(in StateMachineBase stateMachine = null);
        protected abstract void Exit(in StateMachineBase stateMachine = null);
        protected abstract bool CanChangeTo(in StateBase state);
    }
}
