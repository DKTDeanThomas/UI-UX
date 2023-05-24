using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

public class ItemManager : ScriptableObject
{
    public string itemName;
    public float itemPrice;
    public float itemAmount = 0;

    public Sprite itemIcon;
    
    

}
