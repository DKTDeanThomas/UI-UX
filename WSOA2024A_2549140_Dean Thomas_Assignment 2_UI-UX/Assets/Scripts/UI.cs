using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public bool sell = false;

    public GameObject Backpack;
    public GameObject Shop;
    public GameObject Chest;

    public GameObject BackpackCover;

    public GameObject inventoryclose;

    public GameObject shopPrompt;
    public GameObject chestPrompt;
    private inventoryManager instance;

    public GameObject buyButton;


    public void ShopScreen(bool show)
    {
        shopPrompt.SetActive(show);

        
       
    }

    public void ChestScreen(bool show)
    {
        chestPrompt.SetActive(show);

    }

}

   
