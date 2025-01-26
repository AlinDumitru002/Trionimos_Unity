using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece023 : MonoBehaviour
{
    private Piece023_Object piece023Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece023Object = GetComponentInParent<Piece023_Object>();
        if (piece023Object == null)
        {
            Debug.LogError("Piece023_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece023Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece023Object != null)
        {
            piece023Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece023Object != null)
        {
            piece023Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece023Object != null)
        {
            piece023Object.Click();
        }
    }
}
