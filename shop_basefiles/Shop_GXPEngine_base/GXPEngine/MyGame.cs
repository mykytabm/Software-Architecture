using Core;
using GXPEngine;
using States;
using Model;
using Interfaces;
using System.Collections.Generic;
using System;

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
        CreateObjects();
    }

    //------------------------------------------------------------------------------------------------------------------------
    //                                                  CreateObjects()
    //------------------------------------------------------------------------------------------------------------------------        
    private void CreateObjects()
    {
        _player = new Player();
        Player = _player;
        generator = new Generator(new NormalFactory());
        var shopItemList = generator.CreateRandomItems(10);
        _shopBrowseState = new ShopBrowseState(shopItemList);

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