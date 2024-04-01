using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TileManager : MonoBehaviour
{
    [SerializeField] private Tilemap interactableMap;
    [SerializeField] private Tile hiddenInteractableTile;

    [SerializeField] private Tile interactedTile;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var position in interactableMap.cellBounds.allPositionsWithin)
        {
            TileBase tile = interactableMap.GetTile(position);

            if (tile != null&& tile.name == "Interactable_Visable")
            {
                interactableMap.SetTile(position, hiddenInteractableTile);

            }




        }



    }

   public bool isInteractable(Vector3Int position)
    {
        TileBase title = interactableMap.GetTile(position);

        if (title != null)
        {
            if (title.name == "Interactable")
            {
                return true;
            }
        }
        return false;
 
    }

    public void SetInteracted(Vector3Int position)
    {
        interactableMap.SetTile(position, interactedTile);
    }

}
