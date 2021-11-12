using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] ships;

    public TextMeshPro header;

    public Color redColor;

    public Color blueColor;

    public bool redTurn = true;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(ships.Length);
        ships[0].GetComponent<ShipScript>().setPosition(2, 2, false); //4

        ships[1].GetComponent<ShipScript>().setPosition(4, 4, true); //3
        ships[2].GetComponent<ShipScript>().setPosition(6, 6, false); //3

        ships[3].GetComponent<ShipScript>().setPosition(3, 8, true); //2
        ships[4].GetComponent<ShipScript>().setPosition(9, 9, false);//2
        ships[5].GetComponent<ShipScript>().setPosition(7, 1, false);//2

        ships[6].GetComponent<ShipScript>().setPosition(6, 4, true); //1
        ships[7].GetComponent<ShipScript>().setPosition(7, 9, true); //1
        ships[8].GetComponent<ShipScript>().setPosition(8, 4, true); //1
        ships[9].GetComponent<ShipScript>().setPosition(2, 6, true); //1
        ships[10].GetComponent<ShipScript>().setPosition(1, 8, true);//1
        foreach(GameObject ship in ships)
        {
            ship.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    
    public void setRedTurn()
    {
        header.text = "Ход красных";
        header.color = redColor;
        redTurn = true;
    }

    public void setBlueTurn()
    {
        header.text = "Ход синих";
        header.color = blueColor;
        redTurn = false;
    }
}
