using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inventory;

public class Inventory_UI : MonoBehaviour
{
    public class Slot
    {
        public string itemName;
        public Sprite icon;
        public int count;
    }

    public GameObject inventoryPanel;
    public player player;
    public List<Slots> slots=new List<Slots>();

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }


    public void ToggleInventory()
    {
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            refresh();
        }else
        {
            inventoryPanel.SetActive(false);
        }
    }

    void refresh()
    {
        if (slots.Count == player.inventory.slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (player.inventory.slots[i].itemName != "")
                {
                    // Replace the problematic line with the corrected code
                    Inventory_UI.Slot inventorySlot = new Inventory_UI.Slot
                    {
                        itemName = player.inventory.slots[i].itemName,
                        icon = player.inventory.slots[i].icon,
                        count = player.inventory.slots[i].count
                    };
                    slots[i].SetItem(inventorySlot);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }

    }

    public void Remove(int slotID)
    {

        Item itemDrop = GameManager.instance.item_manager.GetItemByName(player.inventory.slots[slotID].itemName);


        if (itemDrop != null)
        {
            player.DropItem(itemDrop);
            player.inventory.Remove(slotID);
            refresh();
        }

     
    }

}
