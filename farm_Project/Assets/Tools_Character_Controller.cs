using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools_Character_Controller : MonoBehaviour
{
    Character_Controller_2D character;
    Rigidbody2D rigidbody;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeofInteractableArea = 1.2f;
    private void Awake()
    {
        character = GetComponent<Character_Controller_2D>();
        rigidbody = GetComponent<Rigidbody2D>();
    }



    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UseTool();
        }
    }

    private void UseTool()
    {
        Vector2 position = rigidbody.position + character.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeofInteractableArea);

        foreach (Collider2D collider in colliders)
        {
            ToolHit hit = collider.GetComponent<ToolHit>();
            if (hit != null)
            {

                hit.Hit();
                break;
            }
        }

    }
}
