namespace itismarciiExtansion.Runtime.Pattern
{
    public interface ICommandType<in T> : ICommand
    {
        public void Execute(T command);
    }
}
