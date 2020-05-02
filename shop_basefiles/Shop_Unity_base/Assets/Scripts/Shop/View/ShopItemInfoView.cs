using System;
using System.Collections;
using System.Collections.Generic;
using Hobgoblin.Model;
using Hobgoblin.Utils;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemInfoView : MonoBehaviour, IObserver<ShopData>
{
    public Text ItemName;
    public Text ItemPrice;
    public Text ItemAmount;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        ItemName.text = "";
        ItemPrice.text = "";
        ItemAmount.text = "";

    }

    public void Subscribe(ShopModel pModel)
    {
        pModel.Subscribe(this);
    }

    public void OnCompleted()
    {
        ItemName.text = "";
        ItemPrice.text = "";
        ItemAmount.text = "";
    }

    public void OnError(Exception error)
    {

    }

    public void OnNext(ShopData pData)
    {
        ItemName.text = pData.selectedItem.name;
        ItemPrice.text = $"Item price: {pData.selectedItem.price}";
        ItemAmount.text = $"Item Amount: {pData.selectedItem.Amount}";
    }
}
