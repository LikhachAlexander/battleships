using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] ships;

    public TextMeshPro header;

    public TextMeshPro redPointsText;

    public TextMeshPro bluePointsText;

    public TextMeshPro winnerBanner;

    public Color redColor;

    public Color blueColor;

    public bool isRedTurn = true;

    public int redPoints = 0;

    public int bluePoints = 0;

    bool transition = false;
    float timeLeft = 2f;
    Vector3 targetPostion = new Vector3(10f, 7.5f, 10.95f);


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
        winnerBanner.enabled = false;
        setRedTurn();
    }

    
    public void setRedTurn()
    {
        header.text = "Ход красных";
        header.color = redColor;
        isRedTurn = true;
    }

    public void setBlueTurn()
    {
        header.text = "Ход синих";
        header.color = blueColor;
        isRedTurn = false;
    }

    public void increaseRed()
    {
        redPoints++;
        redPointsText.text = redPoints.ToString();
    }

    public void increaseBlue()
    {
        bluePoints++;
        bluePointsText.text = bluePoints.ToString();
    }


    public bool isGameEnd()
    {
        bool gameEnd = true;
        foreach (GameObject ship in ships)
        {
            if (!ship.GetComponent<ShipScript>().isDead)
            {
                gameEnd = false;
            }
        }
        return gameEnd;

    }

    public void checkGameEnd()
    {
        if (isGameEnd())
        {
            if(redPoints > bluePoints)
            {
                Debug.Log("Победа красных!");
                winnerBanner.text = "Победа\nкрасных";
                winnerBanner.color = redColor;
            } else
            {
                Debug.Log("Победа синих!");
                winnerBanner.text = "Победа\nсиних";
                winnerBanner.color = blueColor;
            }
            winnerBanner.enabled = true;
            transition = true;
        }
    }

    private void Update()
    {
        // banner movement
        if (transition)
        {
            if (timeLeft <= Time.deltaTime)
            {
                // transition complete
                // assign the target color

                // start a new transition
                winnerBanner.transform.position = targetPostion;
                transition = false;
            }
            else
            {
                // transition in progress
                // calculate interpolated color
                winnerBanner.transform.position = Vector3.Lerp(winnerBanner.transform.position, targetPostion, Time.deltaTime / timeLeft);

                // update the timer
                timeLeft -= Time.deltaTime;
            }
        }
    }
}
