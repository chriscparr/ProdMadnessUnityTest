using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorSphere : MonoBehaviour {

    private Color m_color = Color.yellow;
    public Color SphereColor {get{ return m_color;} set{ m_color = value; m_renderer.material.color = m_color;  }}

    private MeshRenderer m_renderer;

    private void Awake()
    {
        m_renderer = gameObject.GetComponent<MeshRenderer>();
        Reset();
    }

    public void Reset()
    {
        SphereColor = Color.yellow;
    }
}