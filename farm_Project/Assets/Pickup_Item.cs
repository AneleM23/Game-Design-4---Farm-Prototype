using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Item : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 5f;
    [SerializeField] float pickedUpDistance = 1.5f;
    [SerializeField] float ttl = 10f;

    private void Awake()
    {
        player = Game_Manager.instance.player.transform;
    }
    private void Update()
    {

        ttl -= Time.deltaTime;
        if (ttl <= 0)
        {
            Destroy(gameObject);
        }

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance> pickedUpDistance)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position,player.position,speed*Time.deltaTime);

        if (distance < 0.01f)
        {
            Destroy(gameObject);
        }

    }
}
