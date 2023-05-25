using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    public ItemManager item;
    public static shop sInstance;

    public static inventoryManager Instance;

    private void Start()
    {
        sInstance = this;
    }


    public void Buy()
    {

        if (item.itemPrice <= inventoryManager.Instance.playerMoney)
        {
            if (!inventoryManager.Instance.isfull)
            {
                inventoryManager.Instance.itemReceive(item);
                CurrencySubtract(item.itemPrice);
            }
            else
                Debug.Log("clear up space in inverntory");

        }
        else
            Debug.Log("GOT DAM YO ASS IS BROKE GET ON EBT NOW");


    }

    public void Sell(ItemManager items, GameObject slotObject)
    {
        inventoryManager.Instance.SpawnInventory();

        inventoryManager.Instance.itemGive(items);
        CurrencyAdd(items.itemPrice);
        Destroy(slotObject);
    }

 

    void CurrencySubtract(float money)
    {
        if (inventoryManager.Instance.isfull)
        {
            inventoryManager.Instance.currentFunds.text = inventoryManager.Instance.currentFunds.text;
        }
        else
        {
            money = inventoryManager.Instance.playerMoney - item.itemPrice;
            inventoryManager.Instance.currentFunds.text = money.ToString();
            inventoryManager.Instance.playerMoney = money;         
        }
    }

    void CurrencyAdd(float money)
    {
        if (inventoryManager.Instance.isfull)
        {
            inventoryManager.Instance.currentFunds.text = inventoryManager.Instance.currentFunds.text;
        }
        else
        {
            money = inventoryManager.Instance.playerMoney - item.itemPrice;
            inventoryManager.Instance.currentFunds.text = money.ToString();
            inventoryManager.Instance.playerMoney = money;
        }
    }


}
