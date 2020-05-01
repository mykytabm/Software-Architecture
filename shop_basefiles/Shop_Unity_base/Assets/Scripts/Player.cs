using System.Collections;
using System.Collections.Generic;
using Hobgoblin.Core;
using Hobgoblin.Interfaces;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Humanoid _humanoid;

    void Start()
    {
        _humanoid = new Humanoid(new List<Hobgoblin.Model.Item>(), 10, 1000, 0);
    }

    void Update()
    {

    }
    public Humanoid GetHumanoid()
    {
        return _humanoid;
    }
}
