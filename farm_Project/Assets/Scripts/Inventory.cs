using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class slot
    {
        public string itemName;
        public int count;
        public int maxAllowed;

        public Sprite icon;
        public slot()
        {
            itemName = "";
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

        public void Additem(Item item) 
        {
            this.itemName = item.data.itemName;
            this.icon = item.data.icon;
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
                    itemName = "";
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
    public void Add(Item item)
    {
        foreach (slot slot in slots)
        {
            if (slot.itemName == item.data.itemName && slot.CanAddItem())
            {
                slot.Additem(item);
                return;
            }
        }
        foreach (slot slot in slots)
        {
            if (slot.itemName == "")
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