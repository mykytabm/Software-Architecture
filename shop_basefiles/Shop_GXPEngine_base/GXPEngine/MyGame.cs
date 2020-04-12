using Character;
using GXPEngine;
using States;
using Utils;
using Interfaces;
using Model;
using System.Collections.Generic;

public class MyGame : Game
{

    private ShopBrowseState _shopBrowseState;
    private Player _player;

    public Generator generator;
    public static Player Player;

    //------------------------------------------------------------------------------------------------------------------------
    //                                                  MyGame()
    //------------------------------------------------------------------------------------------------------------------------        
    public MyGame() : base(800, 600, false)
    {
        _player = new Player();
        new NormalFactory();
        generator = new Generator(new NormalFactory());
        Player = _player;
        var items = new List<Item>();
        for (int i = 0; i < 10; i++)
        {
            var item = generator.CreateRandomItem();
            items.Add(item);
        }
        _shopBrowseState = new ShopBrowseState(items);
        AddChild(_player);
        AddChild(_shopBrowseState);
    }

    //------------------------------------------------------------------------------------------------------------------------
    //                                                  Update()
    //------------------------------------------------------------------------------------------------------------------------        
    void Update()
    {
        _shopBrowseState.Step();
    }

    //------------------------------------------------------------------------------------------------------------------------
    //                                                  Main()
    //------------------------------------------------------------------------------------------------------------------------        
    static void Main()
    {
        new MyGame().Start();
    }
}