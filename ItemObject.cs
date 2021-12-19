using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New food object",menuName ="Inventory System/Item/Food object")]
public class ItemObject : ScriptableObject
{
    
    public enum ItemType
    {
        Apple,
        Pineapple,
        Melon,
        Watermelon,
        Banana,
        Mango,
    }
    public int Id;
    public ItemType itemType;
    public int cost;
    public Sprite sprite;

}

[System.Serializable]
public class Item
{
    public string Name;
    public int Id;
    public int cost;
    public Item (ItemObject item){

        Name = item.name;
        Id = item.Id;
        cost = item.cost;
    }
}
