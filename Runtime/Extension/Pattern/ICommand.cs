namespace itismarciiExtansion.Runtime.Pattern
{
    public interface ICommand
    {
        public void Execute();

        public void Undo();
    }
}
