using System;
namespace Interfaces
{
    public interface ICommandExecutor<TCommand>
        where TCommand: ICommand
    {
        void Execute(TCommand pCommand);
    }
}
