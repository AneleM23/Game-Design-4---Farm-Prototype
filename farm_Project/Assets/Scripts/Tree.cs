using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tree : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 1.0f; // Adjustable interaction distance in Inspector
    [SerializeField] private GameObject logPrefab; // Reference to Log prefab in Inspector
    [SerializeField] private int numLogsToSpawn = 3; // Number of Log prefabs to spawn (adjustable in Inspector)
   
    private void OnMouseDown()
    {
        // Check if player is near enough
        if (IsPlayerNear())
        {

            // Destroy the tree
            Destroy(gameObject);

            // Spawn Log prefabs
            for (int i = 0; i < numLogsToSpawn; i++)
                {
                    // Calculate random position offset within a reasonable range
                    Vector3 randomOffset = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0f);

                    // Spawn a Log prefab with random offset
                    Instantiate(logPrefab, transform.position + randomOffset, Quaternion.identity);
                }
           
        }
    }

    private bool IsPlayerNear()
    {
        // Check if player object has a collider with a specific tag (optional)
        string playerTag = "Player"; // Replace with your player tag if needed

        // Check for colliders within interaction distance
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionDistance);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag(playerTag)) // Check for both player and tool (optional)
            {
                return true;
            }
        }

        return false;
    }

  
}
