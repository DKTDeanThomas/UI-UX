using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class inventoryManager : MonoBehaviour
{
    public static inventoryManager Instance;
    public UI ui;
    public Text inventSpace;
    public Text chestSpace;

    public Text currentFunds;

    public Transform slotPanel;
    public GameObject slots;

    public Transform chestslotPanel;
    public GameObject chestSlots;

    public int maxItems = 4;
    public int maxchestItems = 5;

    private int chestcount;
    private int itemcount;
    public bool isfull = false;

    public float playerMoney = 100;

    public static shop sInstance;
    public ItemManager item;

    public GameObject moveOverlay;

    public List<ItemManager> backpackItems = new List<ItemManager>();
    public List<ItemManager> chestItems = new List<ItemManager>();

    public bool isPack = false;
    public bool isChest = false;

    private Button button;

    public GameObject BPUpgrade;
   



    private void Start()
    {
        Instance = this;
        itemcount = maxItems;
        chestcount = maxchestItems;
    }


    public void itemReceive(ItemManager items)
    {
        isPack = true;
        isfull = false;
        if (backpackItems.Count < maxItems)
        {
            isfull = false;
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
        isPack = true;
        backpackItems.Remove(items);
        Increment(ref itemcount);
    }

    
    public void ChestReceive(ItemManager items)
    {
        isChest = true;
        if (chestItems.Count < maxchestItems)
        {

            chestItems.Add(items);
            Decrement(ref chestcount);

        }

        else
        {
            isfull = true;

            Debug.Log("inventory full bro");
        }


    }

    public void ChestGive(ItemManager items)
    {
        isChest = true;
        chestItems.Remove(items);
        Increment(ref chestcount);
    }

    public void ExpandStorage()
    {
        if (maxchestItems >= 10)
        {
            Debug.Log("already upgraded");
        }

        
        else
        {
            maxchestItems +=5;
            chestcount +=5 ;
            chestSpace.text = chestcount.ToString();

        }
        

    }


    public void BackpackExpansion()
    {
        if (maxItems >= 8)
        {
            Debug.Log("already upgraded");
        }


        else
        {
            maxItems += 4;
            itemcount += 4;
            inventSpace.text = itemcount.ToString();

        }

        Destroy(BPUpgrade);
    }



    public void Increment(ref int space)
    {
        space++;

        if (isPack)
        {
            inventSpace.text = space.ToString();
            isPack = false;
        }
            
        else if (isChest)
        {
            chestSpace.text = space.ToString();
            isChest = false;
        }
           
        return;
    }

    public void Decrement(ref int space)
    {
        space--;

        if (isPack)
        {
            inventSpace.text = space.ToString();
            isPack = false;
        }

        else if (isChest)
        {
            chestSpace.text = space.ToString();
            isChest = false;
        }

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


            var itemName = spwn.transform.Find("itemName").GetComponent<Text>();
            var itemIcon = spwn.transform.Find("itemImage").GetComponent<Image>();
            var itemPrice = spwn.transform.Find("itemPrice").GetComponent<Text>();
           


            itemName.text = item.itemName;
            itemIcon.sprite = item.itemIcon;
            itemPrice.text = item.itemPrice.ToString();

            spwn.transform.Find("itemImage").AddComponent<Button>();
            button = spwn.transform.Find("itemImage").GetComponent<Button>();

            button.onClick.AddListener(() => TransferToChest(item, spwn));


                
        }
    }

    public void SpawnChest()
    {
        foreach (Transform items in chestslotPanel)
        {
            Destroy(items.gameObject);
        }

        

        foreach (var item in chestItems)
        {

            GameObject chestspwn = Instantiate(chestSlots, chestslotPanel);
            var itemName = chestspwn.transform.Find("itemName").GetComponent<Text>();
            var itemIcon = chestspwn.transform.Find("itemImage").GetComponent<Image>();
            var itemPrice = chestspwn.transform.Find("itemPrice").GetComponent<Text>();
            


            itemName.text = item.itemName;
            itemIcon.sprite = item.itemIcon;
            itemPrice.text = item.itemPrice.ToString();

            chestspwn.transform.Find("itemImage").AddComponent<Button>();
            button = chestspwn.transform.Find("itemImage").GetComponent<Button>();
            button.onClick.AddListener(() => TransferToBackpack(item, chestspwn));

        }
    }



    public void TransferToChest(ItemManager item, GameObject slotObject)
    {
        Debug.Log("Clicked");
        if (chestItems.Count < maxchestItems)
        {
            if (isfull)
            {
                isfull = false;
            }
            itemGive(item);          
            ChestReceive(item);
            SpawnChest();

            Destroy(slotObject);
        }
        else
        {
            Debug.Log("Chest is full");
        }
    }

    public void TransferToBackpack(ItemManager item, GameObject slotObject)
    {
        Debug.Log("Clicked");
        if (backpackItems.Count < maxItems)
        {
            ChestGive(item);
            itemReceive(item);

            SpawnInventory();

            Destroy(slotObject);
        }
        else
        {
            Debug.Log("Backpack is full");
        }
    }


   
}


