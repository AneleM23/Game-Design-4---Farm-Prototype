using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Manager : MonoBehaviour
{
    public Item[] items;

    private Dictionary<string, Item> nameToItemDict= new Dictionary<string, Item>();


    private void Awake()
    {
        foreach (Item item in items)
        {
            Additem(item);
        }
    }



    public void Additem(Item item)
    {
        if (!nameToItemDict.ContainsKey(item.data.itemName))
        {
            nameToItemDict.Add(item.data.itemName, item);
        }
    }

    public Item GetItemByName(string key)
    {
        if (nameToItemDict.ContainsKey(key))
        {
            return nameToItemDict[key];
        }

        return null;
    }

}
