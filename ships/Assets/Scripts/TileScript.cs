using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public Color switchColor;

    public float switchTime;



    Color m_OriginalColor;

    MeshRenderer m_Renderer;

    bool transition = false;

    float timeLeft;


    void Start()
    {
        //Fetch the mesh renderer component from the GameObject
        m_Renderer = GetComponent<MeshRenderer>();
        //Fetch the original color of the GameObject
        m_OriginalColor = m_Renderer.material.color;
    }

    void OnMouseOver()
    {
        // Change the color of the GameObject to red when the mouse is over GameObject
        m_Renderer.material.color = switchColor;
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

                // start a new transition
                transition = false;
            }
            else
            {
                // transition in progress
                // calculate interpolated color
                m_Renderer.material.color = Color.Lerp(m_Renderer.material.color, m_OriginalColor, Time.deltaTime / timeLeft);

                // update the timer
                timeLeft -= Time.deltaTime;
            }
        }
    }
}
