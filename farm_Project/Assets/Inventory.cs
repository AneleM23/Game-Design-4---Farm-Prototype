using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<GameObject> items = new List<GameObject>();

    public GameObject inventoryUI;


    public class Slot
    {
        public Sprite icon;
        public int count;

        public Slot(Sprite icon, int count)
        {
            this.icon = icon;
            this.count = count;
        }
    }

    public void AddItem(GameObject item)
    {
        items.Add(item);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inventoryUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            inventoryUI.SetActive(false);
        }
    }

}
