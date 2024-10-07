using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuable : MonoBehaviour
{
    Color m_MouseOverColor = Color.green;
    Color m_OriginalColor;

    MeshRenderer m_Renderer;

    void Start()
    {
        if (this.GetComponent<MeshRenderer>() != null)
        { 
            m_Renderer = GetComponent<MeshRenderer>();
        } 
        else
        {
            m_Renderer = GetComponentInChildren<MeshRenderer>();
            m_MouseOverColor = Color.black;
        }

        m_OriginalColor = m_Renderer.material.color;
    }

    void OnMouseOver()
    {
        m_Renderer.material.color = m_MouseOverColor;
    }

    void OnMouseExit()
    {
        m_Renderer.material.color = m_OriginalColor;
    }
}
