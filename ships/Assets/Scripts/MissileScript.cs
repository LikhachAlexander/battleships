using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Missile hit " + other.gameObject.name);
        if (other.gameObject.tag == "Tile")
        {
            Destroy(gameObject);
        }
    }
}