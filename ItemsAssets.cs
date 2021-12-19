using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsAssets : MonoBehaviour
{
   public static ItemsAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public ItemObject appleItem;
    public ItemObject pineappleItem;
    public ItemObject melonItem;
    public ItemObject watermelonItem;
    public ItemObject mangoItem;
    public ItemObject bananaItem;

}
