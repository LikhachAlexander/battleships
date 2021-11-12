using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{

    public int size;
    public int hp;
    public bool isDead = false;

    bool dir; // dir: up - true, right - false


    public List<GameObject> shipTiles = new List<GameObject>(); //tiles that collide with ship

    // Start is called before the first frame update

    private Vector3 getZeroPos()
    {
        float x0, y0, z0;
        if (dir) {
            if (size == 4)
            {
                x0 = -6.5f;
                y0 = -0.8f;
                z0 = -3f;
            } else if (size == 3)
            {
                x0 = -6.5f;
                y0 = -0.8f;
                z0 = -4.15f;
            }
            else if (size == 2)
            {
                x0 = -6.5f;
                y0 = -1.2f;
                z0 = -5.25f;
            } else
            {
                x0 = -6.5f;
                y0 = -3.1f;
                z0 = -6.4f;
            }
        } else
        {
            if (size == 4)
            {
                x0 = -3.27f;
                y0 = -0.8f;
                z0 = -6.33f;
            }
            else if (size == 3)
            {
                x0 = -4.3f;
                y0 = -0.8f;
                z0 = -6.4f;
            }
            else if (size == 2)
            {
                x0 = -5.4f;
                y0 = -1.2f;
                z0 = -6.4f;
            }
            else
            {
                x0 = -6.5f;
                y0 = -3.1f;
                z0 = -6.4f;
            }
        }
        return new Vector3(x0, y0, z0);
    }


    // moves ship to a, b pos (1:10)
    public void setPosition(int a, int b, bool direction)
    {
        dir = direction;
        Vector3 startPos = getZeroPos();
        Vector3 diff = new Vector3((a - 1) * 2.25f, 0f, (b - 1) * 2.25f);
        startPos = startPos + diff;
        transform.localPosition = startPos;
        if (!dir)
        {
            Vector3 ang = transform.eulerAngles;
            ang.y += 90;
            transform.eulerAngles = ang;
        }
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Tile")
        {
            shipTiles.Add(col.gameObject);

            
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Tile")
        {
            // Remove the GameObject collided with from the list.
            shipTiles.Remove(col.gameObject);

            
        }
    }

    public List<GameObject> getNeighbourTiles()
    {
        return GetComponentInChildren<ShipBoxScript>().shipNeighbourTiles;
    } 

    public void dealDamage()
    {
        hp--;
        if (hp == 0)
        {
            isDead = true;
            // show ship
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

}
