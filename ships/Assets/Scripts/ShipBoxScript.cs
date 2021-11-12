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

            // Print the entire list to the console.
            foreach (GameObject gObject in shipNeighbourTiles)
            {
                print(gObject.name);
            }
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Tile")
        {
            // Remove the GameObject collided with from the list.
            shipNeighbourTiles.Remove(col.gameObject);

            // Print the entire list to the console.
            foreach (GameObject gObject in shipNeighbourTiles)
            {
                print(gObject.name);
            }
        }
    }
}
