using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public Color switchColor;

    public float switchTime;

    public GameObject digit;

    public GameObject letter;



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

    void OnMouseOver()
    {
        // Change the color of the GameObject to red when the mouse is over GameObject
        m_Renderer.material.color = switchColor;

        letter_textMesh.color = switchColor;
        digit_textMesh.color = switchColor;
        timeLeft = 0f;
    }

    void OnMouseExit()
    {
        // Reset the color of the GameObject back to normal
        // m_Renderer.material.color = m_OriginalColor;

        //start transition
        transition = true;
        timeLeft = switchTime;
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
