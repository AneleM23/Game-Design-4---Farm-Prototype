using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class slot
    {
        public CollectableType type;
        public int count;
        public int maxAllowed;

        public Sprite icon;
        public slot()
        {
            type = CollectableType.NONE;
            count = 0;
            maxAllowed = 99;
        }
        public bool CanAddItem()
        {
            if (count<maxAllowed)
            {
                return true;
            }
            return false;
        }

        public void Additem(collectable item) 
        {
            this.type = item.type;
            this.icon = item.Icon;
            count++;
        }
        public void RemoveItem()
        {
            if (count > 0)
            {
                count--;
                if (count == 0)
                {
                    icon = null;
                    type = CollectableType.NONE;
                }

            }
        }
    }

    public List<slot> slots = new List<slot>();

    public Inventory(int numSlots)
    {
        for (int i = 0; i < numSlots; i++)
        {
            slot slot = new slot();
            slots.Add(slot);
        }
    }
    public void Add(collectable item)
    {
        foreach (slot slot in slots)
        {
            if (slot.type == item.type && slot.CanAddItem())
            {
                slot.Additem(item);
                return;
            }
        }
        foreach (slot slot in slots)
        {
            if (slot.type == CollectableType.NONE)
            {
                slot.Additem(item);
                return;
            }
        }
                
    }

    public void Remove(int index)
    {
        slots[index].RemoveItem();
    }

}