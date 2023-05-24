using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{

    public static inventoryManager Instance;
    private void OnMouseDown()
    {
        Debug.Log("click");
        Instance.Transfer();
    }
}
