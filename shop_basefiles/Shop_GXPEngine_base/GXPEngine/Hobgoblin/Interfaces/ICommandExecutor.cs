using System;
namespace Hobgoblin.Interfaces
{
    public interface ICommandExecutor<TCommand> : IService
        where TCommand : ICommand
    {
        void Execute(TCommand pCommand);
    }
}
