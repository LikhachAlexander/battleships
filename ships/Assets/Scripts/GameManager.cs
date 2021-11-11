using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] ships;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(ships.Length);
        ships[0].GetComponent<ShipScript>().setPosition(1, 1, false); //4

        ships[1].GetComponent<ShipScript>().setPosition(3, 3, true); //3
        ships[2].GetComponent<ShipScript>().setPosition(5, 6, false); //3

        ships[3].GetComponent<ShipScript>().setPosition(3, 8, true); //2
        ships[4].GetComponent<ShipScript>().setPosition(9, 9, false);//2
        ships[5].GetComponent<ShipScript>().setPosition(6, 1, false);//2

        ships[6].GetComponent<ShipScript>().setPosition(5, 4, true); //1
        ships[7].GetComponent<ShipScript>().setPosition(7, 9, true); //1
        ships[8].GetComponent<ShipScript>().setPosition(8, 4, true); //1
        ships[9].GetComponent<ShipScript>().setPosition(1, 6, true); //1
        ships[10].GetComponent<ShipScript>().setPosition(1, 8, true);//1
        foreach(GameObject ship in ships)
        {
            ship.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
