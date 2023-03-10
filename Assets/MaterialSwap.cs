using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwap : MonoBehaviour
{
    // https://docs.unity3d.com/ScriptReference/Material.SetTexture.html
    public Material m1, m2;
    public Renderer m_Renderer;
    private bool mat = true;

    void Start()
    {
        m_Renderer = GetComponent<Renderer> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) { 
            mat = !mat;
            if (mat) {
                m_Renderer.material = m1;
            } else {
                m_Renderer.material = m2;
            }
        }
    }
}
