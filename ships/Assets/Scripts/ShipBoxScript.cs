using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBoxScript : MonoBehaviour
{
    public List<GameObject> shipNeighbourTiles = new List<GameObject>(); //tiles around the ship

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Tile")
        {
            shipNeighbourTiles.Add(col.gameObject);

            
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Tile")
        {
            // Remove the GameObject collided with from the list.
            shipNeighbourTiles.Remove(col.gameObject);

           
        }
    }
}
