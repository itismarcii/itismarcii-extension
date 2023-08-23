using System.Collections.Generic;

namespace itismarciiExtansion.Runtime.Pattern
{
    public abstract class CommandBrain
    {
        protected readonly Stack<ICommand> Commands = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            Commands.Push(command);
        }

        public void UndoCommand()
        {
            if(Commands.Count <= 0) return;
            var command = Commands.Pop();
            command.Undo();
        }
    }
}
