using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class inventoryManager : MonoBehaviour
{
    public static inventoryManager Instance;
    public Text inventSpace;
    public Text chestSpace;

    public Text currentFunds;

    public Transform slotPanel;
    public GameObject slots;

    public Transform chestslotPanel;
    public GameObject chestSlots;

    public int maxItems = 4;
    public int maxchestItems = 5;

    private int itemcount;
    public bool isfull = false;

    public float playerMoney = 100;

    public static shop sInstance;
    public ItemManager item;

    public Toggle enableRemove;


    public List<ItemManager> backpackItems = new List<ItemManager>();
    public List<ItemManager> chestItems = new List<ItemManager>();

    private void Start()
    {
        Instance = this;
        itemcount = maxItems;
    }


    public void itemReceive(ItemManager items)
    {
        if (backpackItems.Count < maxItems)
        {
            
            backpackItems.Add(items);
            Decrement(ref itemcount);

        }

        else
        {
            isfull = true;
           
            Debug.Log("inventory full bro");
        }
        
        
    }

    public void ChestReceive(ItemManager items)
    {
        if (chestItems.Count < maxItems)
        {

            backpackItems.Add(items);
            Decrement(ref itemcount);

        }

        else
        {
            isfull = true;

            Debug.Log("inventory full bro");
        }


    }


    public void itemGive(ItemManager items)
    {
        backpackItems.Remove(items);
        Increment(ref itemcount);
    }




    public void Decrement(ref int space)
    {
        space--;
        inventSpace.text = space.ToString();
        return;
    }

    public void Increment(ref int space)
    {
        space++;
        inventSpace.text = space.ToString();
        return;
    }


    public void SpawnInventory()
    {
        foreach (Transform items in slotPanel)
        {
            Destroy(items.gameObject);
        }
        
        foreach (var item in backpackItems)
        {
            GameObject spwn = Instantiate(slots, slotPanel);
     

            spwn.AddComponent<ClickHandler>();
            var itemName = spwn.transform.Find("itemName").GetComponent<Text>();
            var itemIcon = spwn.transform.Find("itemImage").GetComponent<Image>();
            var itemPrice = spwn.transform.Find("itemPrice").GetComponent<Text>();


            itemName.text = item.itemName;
            itemIcon.sprite = item.itemIcon;
            itemPrice.text = item.itemPrice.ToString();


        }
    }

    public void SpawnChest()
    {
        foreach (Transform items in chestslotPanel)
        {
            Destroy(items.gameObject);
        }

        Transfer();

        foreach (var item in chestItems)
        {
            GameObject chestspwn = Instantiate(chestSlots, chestslotPanel);
            var itemName = chestspwn.transform.Find("itemName").GetComponent<Text>();
            var itemIcon = chestspwn.transform.Find("itemImage").GetComponent<Image>();
            var itemPrice = chestspwn.transform.Find("itemPrice").GetComponent<Text>();
            


            itemName.text = item.itemName;
            itemIcon.sprite = item.itemIcon;
            itemPrice.text = item.itemPrice.ToString();


        }
    }

    public void Transfer()
    {
        foreach(ItemManager item in backpackItems)
        {
            chestItems.Add(item);
        }
    }


    public void ExpandStorage(ref int chestspace)
    {
        maxchestItems = 10;
        chestSpace.text = chestspace.ToString();
    }
    
}


