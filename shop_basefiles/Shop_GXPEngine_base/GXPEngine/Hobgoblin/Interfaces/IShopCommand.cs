using System;
using Hobgoblin.Controller;
namespace Hobgoblin.Interfaces
{
    public interface IShopCommand : ICommand
    {
        new void Execute();
    }
}
