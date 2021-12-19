using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public MouseItem mouseItem = new MouseItem();
    public InventoryObject inventory;

    public void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            inventory.Load();
        }

    }

    private void OnApplicationQuit()
    {
        inventory.Container.Items = new InventorySlot[16];
    }
}
