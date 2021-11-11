using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] ships;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(ships.Length);
        ships[0].GetComponent<ShipScript>().setPosition(1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
