using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece244 : MonoBehaviour
{
    private Piece244_Object piece244Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece244Object = GetComponentInParent<Piece244_Object>();
        if (piece244Object == null)
        {
            Debug.LogError("Piece244_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece244Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece244Object != null)
        {
            piece244Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece244Object != null)
        {
            piece244Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece244Object != null)
        {
            piece244Object.Click();
        }
    }
}
