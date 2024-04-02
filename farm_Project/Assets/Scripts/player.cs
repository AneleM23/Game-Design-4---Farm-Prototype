using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{ 
  public Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory(24);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3Int position = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);

            if (GameManager.instance.tile_manager.isInteractable(position))
            {
                Debug.Log("Tile is interactable");
                GameManager.instance.tile_manager.SetInteracted(position);

            }

        }
    }

    public void DropItem(Item item)
    {
        Vector3 spawnLoaction = transform.position;



        Vector3 spawnOffset = Random.insideUnitSphere * 1.25f;

        Item droppeditem = Instantiate(item,spawnLoaction+spawnOffset, Quaternion.identity);

        droppeditem.rb2d.AddForce(spawnOffset * 2f, ForceMode2D.Impulse);
    }
}
