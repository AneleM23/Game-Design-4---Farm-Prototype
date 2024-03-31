using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Manager : MonoBehaviour
{
    public collectable[] collectableItems;

    private Dictionary<CollectableType, collectable> collectableitemDict= new Dictionary<CollectableType, collectable>();


    private void Awake()
    {
        foreach (collectable item in collectableItems)
        {
            Additem(item);
        }
    }



    public void Additem(collectable item)
    {
        if (!collectableitemDict.ContainsKey(item.type))
        {
            collectableitemDict.Add(item.type, item);
        }
    }

    public collectable GetItemByType(CollectableType type)
    {
        if (collectableitemDict.ContainsKey(type))
        {
            return collectableitemDict[type];
        }

        return null;
    }

}
