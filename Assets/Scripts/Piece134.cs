using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece134 : MonoBehaviour
{
    private Piece134_Object piece134Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece134Object = GetComponentInParent<Piece134_Object>();
        if (piece134Object == null)
        {
            Debug.LogError("Piece134_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece134Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece134Object != null)
        {
            piece134Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece134Object != null)
        {
            piece134Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece134Object != null)
        {
            piece134Object.Click();
        }
    }
}
