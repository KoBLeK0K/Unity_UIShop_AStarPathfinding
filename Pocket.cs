using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pocket : MonoBehaviour
{
    
    public int money;
    public void Start()
    {
        GetComponent<TextMeshProUGUI>().text = money.ToString();
    }

    //public bool ItemSold()
    //{
    //    if (inventory.name.Contains("Merchant Inventory") == true)
    //        return true;
    //    else 
    //        return false;
    //}

    //public bool ItemBought()
    //{
    //    if (inventory.name.Contains("Player Inventory") == true)
    //        return true;
    //    else
    //        return false;
        
    //}
}
