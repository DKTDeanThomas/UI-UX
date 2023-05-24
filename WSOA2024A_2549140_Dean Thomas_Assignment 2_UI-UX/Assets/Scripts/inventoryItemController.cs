using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryItemController : MonoBehaviour
{
    ItemManager item;
    public static shop sInstance;

    public Button sell;
    public void RemoveItem()
    {
        sInstance.Sell();
    }

    public void AddItem(ItemManager items)
    {
        item = items;
    }
}
