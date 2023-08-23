namespace itismarciiExtansion.Runtime.Pattern
{
    
    public abstract class CommandBrainType<T> : CommandBrain
    {
        public void ExecuteCommand(ICommandType<T> command, T variable)
        {
            command.Execute(variable);
            Commands.Push(command);
        }
    }
}
