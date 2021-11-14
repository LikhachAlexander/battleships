using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileScript : MonoBehaviour
{
    [Header("Health Settings")]

    public GameManager gameManager;

    [Header("Colors switch")]
    [ColorUsage(true, true)]

    public Color switchColor;

    public float switchTime;

    public GameObject digit;

    public GameObject letter;

    [Header("Colors hit")]

    [ColorUsage(true, true)]
    public Color grey;

    [ColorUsage(true, true)]
    public Color blueHit;

    [ColorUsage(true, true)]
    public Color redHit;

    public bool isHit = false;

    [Header("Objects")]

    public GameObject missilePrefab;

    public GameObject firePrefab;

    public GameObject smallExplosionPrefab;

    Color m_OriginalColor;

    MeshRenderer m_Renderer;

    Color l_OriginalColor;

    TextMeshPro  letter_textMesh;

    TextMeshPro digit_textMesh;

    bool transition = false;

    float timeLeft;



    void Start()
    {
        // Tile
        m_Renderer = GetComponent<MeshRenderer>();
        m_OriginalColor = m_Renderer.material.color;

        // letter
        letter_textMesh = letter.GetComponent<TextMeshPro>();
        l_OriginalColor = letter_textMesh.color;

        // digit 
        digit_textMesh = digit.GetComponent<TextMeshPro>();
    }

    // coloring
    void OnMouseOver()
    {
        if (!isHit)
        {
            // Change the color of the GameObject to red when the mouse is over GameObject
            m_Renderer.material.color = switchColor;

            letter_textMesh.color = switchColor;
            digit_textMesh.color = switchColor;
            timeLeft = 0f;

            // click
            if (Input.GetMouseButtonDown(0) && !isHit)
            {
                // set hit
                isHit = true;

                // reset colors
                m_Renderer.material.color = m_OriginalColor;
                letter_textMesh.color = l_OriginalColor;
                digit_textMesh.color = l_OriginalColor;

                transition = false;

                // spawn missile
                Vector3 tilePos = gameObject.transform.position;
                tilePos.y += 15;
                Instantiate(missilePrefab, tilePos, missilePrefab.transform.rotation);

                // start checking hit after missile landing
                Invoke("checkHit", 1.8f);
                

            }
        }
    }

    void setGrey()
    {
        isHit = true;

        m_Renderer.material.color = grey;

        letter_textMesh.color = l_OriginalColor;
        digit_textMesh.color = l_OriginalColor;

        transition = false;
    }

    void checkHit()
    {
        // spawn explosion
        


        // check if tile is in ship tiles
        bool isShip = false;
        foreach (GameObject ship in gameManager.ships)
        {
            List<GameObject> shipTiles = ship.GetComponent<ShipScript>().shipTiles;
            if (shipTiles.Contains(gameObject))
            {
                // hit ship
                Debug.Log("Strike ship! " + ship.name);
                isShip = true;

                // spawn fire
                Vector3 tilePos = gameObject.transform.position;
                tilePos.y += 0.3f;
                Instantiate(firePrefab, tilePos, firePrefab.transform.rotation);
                Instantiate(smallExplosionPrefab, tilePos, smallExplosionPrefab.transform.rotation);

                ship.GetComponent<ShipScript>().dealDamage();


                // paint team color 
                if (gameManager.isRedTurn)
                {
                    m_Renderer.material.color = redHit;
                    gameManager.increaseRed();
                } else
                {
                    m_Renderer.material.color = blueHit;
                    gameManager.increaseBlue();
                }

                // check if isDead
                if (ship.GetComponent<ShipScript>().isDead)
                {
                    Debug.Log("Ship dead! " + ship.name);
                    List<GameObject> shipNeighbourTiles = ship.GetComponent<ShipScript>().getNeighbourTiles();
                    foreach (GameObject tile in shipNeighbourTiles)
                    {
                        if (!tile.GetComponent<TileScript>().isHit)
                        {
                            tile.GetComponent<TileScript>().setGrey();
                        }
                    }
                    // check game end
                    gameManager.checkGameEnd();
                }
            }
        }
        if (!isShip)
        {
            // paint grey
            setGrey();
        }
    }

    void OnMouseExit()
    {
        if (!isHit)
        {
            // Reset the color of the GameObject back to normal
            // m_Renderer.material.color = m_OriginalColor;

            //start transition
            transition = true;
            timeLeft = switchTime;
        }
    }

    private void Update()
    {

        if (transition)
        {
            if (timeLeft <= Time.deltaTime)
            {
                // transition complete
                // assign the target color
                m_Renderer.material.color = m_OriginalColor;

                letter_textMesh.color = l_OriginalColor;
                digit_textMesh.color = l_OriginalColor;

                // start a new transition
                transition = false;
            }
            else
            {
                // transition in progress
                // calculate interpolated color
                m_Renderer.material.color = Color.Lerp(m_Renderer.material.color, m_OriginalColor, Time.deltaTime / timeLeft);

                letter_textMesh.color = Color.Lerp(letter_textMesh.color, l_OriginalColor, Time.deltaTime / timeLeft);
                digit_textMesh.color = Color.Lerp(digit_textMesh.color, l_OriginalColor, Time.deltaTime / timeLeft);

                // update the timer
                timeLeft -= Time.deltaTime;
            }
        }
    }
}
