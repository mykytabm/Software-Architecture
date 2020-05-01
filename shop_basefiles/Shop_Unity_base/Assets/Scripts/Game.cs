using System.Collections;
using System.Collections.Generic;
using Hobgoblin.Core;
using UnityEngine;

public class Game : MonoBehaviour
{
    private CommandManager _commandManager;
    void Start()
    {
        _commandManager = new CommandManager(null);
        ServiceLocator.Instance.AddService(_commandManager);

    }

    void Update()
    {

    }
}
