using System.Collections;
using System.Collections.Generic;
using Hobgoblin.Core;
using Hobgoblin.Interfaces;
using Hobgoblin.Model;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Humanoid _humanoid;

    public void Start()
    {
        if (_humanoid == null)
        {
            InitHumanoid();
        }
    }

    private void InitHumanoid()
    {
        _humanoid = new Humanoid(new List<Hobgoblin.Model.Item>(), 10, 1000, 0);
    }

    public ref Humanoid Humanoid()
    {
        if (_humanoid == null)
        {
            InitHumanoid();
        }
        return ref _humanoid;
    }
}
