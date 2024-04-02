using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Item))]
public class collectable : MonoBehaviour
{

   
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       player player = collision.GetComponent<player>();



        if (player)
        {

            Item item = GetComponent<Item>();

            if (item != null)
            {
                player.inventory.Add(item);

                Destroy(this.gameObject);
            }
           
        }
    }
}

