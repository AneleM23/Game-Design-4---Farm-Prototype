using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable : MonoBehaviour
{

    public CollectableType type;
    public Sprite Icon;

    public Rigidbody2D rb2d;


    public void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       player player = collision.GetComponent<player>();



        if (player)
        {
            player.inventory.Add(this);

            Destroy(this.gameObject);
        }
    }
}

public enum CollectableType
{
    NONE, WEED_SEED
}