using System.Collections;
using System.Collections.Generic;
using Hobgoblin.Core;
using Hobgoblin.Model;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Humanoid PlayerHumanoid;
    private CommandManager _commandManager;
    void Start()
    {
        PlayerHumanoid = new Humanoid(new List<Hobgoblin.Model.Item>(), 10, 1000, 2);
        _commandManager = new CommandManager(null);
        ServiceLocator.Instance.AddService(_commandManager);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


}
