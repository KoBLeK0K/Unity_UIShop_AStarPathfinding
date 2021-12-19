using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "New inventory object", menuName ="Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    
    public string savePath;
    public ItemDatabaseObject database;
    public Inventory Container;

   
    
    public void addItem(Item _item, int _amount, int _cost)
    {

        for (int i = 0; i < Container.Items.Length; i++)
        {
            if (Container.Items[i].ID == _item.Id)
            {
                Container.Items[i].addAmount(_amount);
                return;
            }
        }
        SetEmptySlot(_item, _amount, _cost);
    }
    public InventorySlot SetEmptySlot(Item _item, int _amount, int _cost)
    {
        for (int i = 0; i < Container.Items.Length; i++)
        {
            if(Container.Items[i].ID <= -1)
            {
                Container.Items[i].UpdateSlot(_item.Id, _item, _amount, _cost);
                return Container.Items[i];
            }

        }
        return null;
    }

    public void MoveItem(InventorySlot item1, InventorySlot item2)
    {
        InventorySlot temp = new InventorySlot(item2.ID, item2.item, item2.amount, item2.cost);
        item2.UpdateSlot(item1.ID, item1.item, item1.amount, item1.cost);
        item1.UpdateSlot(temp.ID, temp.item, temp.amount, temp.cost);
    }

    public void RemoveItem(Item _item)
    {
        for (int i = 0; i < Container.Items.Length; i++)
        {
            if (Container.Items[i].item == _item)
            {
                Container.Items[i].UpdateSlot(-1, null, 0, 0);
            }
        }
    }
    [ContextMenu("Save")]
    public void Save()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath),FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, Container);
        stream.Close();
    }
    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)));
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            Inventory newContainer = (Inventory)formatter.Deserialize(stream);
            for (int i = 0; i < Container.Items.Length; i++)
            {
                Container.Items[i].UpdateSlot(newContainer.Items[i].ID, newContainer.Items[i].item, newContainer.Items[i].amount, newContainer.Items[i].cost);
            }
            stream.Close();
        }
        
    }
    [ContextMenu("Clear")]
    public void Clear()
    {
        Container = new Inventory();
    }
}
[System.Serializable]
public class Inventory
{
    public InventorySlot[] Items = new InventorySlot[16];
}
[System.Serializable]
public class InventorySlot{

    public UserInterface parent;
    public int ID;
    public Item item;
    public int amount;
    public int cost;
    public InventorySlot()
    {
        ID = -1;
        item = null;
        amount = 0;
        cost = 0;
    }
    public InventorySlot(int _id, Item _item, int _amount, int _cost)
    {
        ID = _id;
        item = _item;
        amount = _amount;
        cost = _cost;
    }
    public void UpdateSlot(int _id, Item _item, int _amount, int _cost)
    {
        ID = _id;
        item = _item;
        amount = _amount;
        cost = _cost;
    }
    public void addAmount(int value)
    {
        amount += value;
    }
}