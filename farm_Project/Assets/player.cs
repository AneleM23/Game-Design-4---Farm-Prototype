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



    public void DropItem(collectable item)
    {
        Vector3 spawnLoaction = transform.position;



        Vector3 spawnOffset = Random.insideUnitSphere * 1.25f;

        collectable droppeditem = Instantiate(item,spawnLoaction+spawnOffset, Quaternion.identity);

        droppeditem.rb2d.AddForce(spawnOffset * 2f, ForceMode2D.Impulse);
    }
}
