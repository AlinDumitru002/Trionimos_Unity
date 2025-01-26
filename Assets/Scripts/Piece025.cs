using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece025 : MonoBehaviour
{
    private Piece025_Object piece025Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece025Object = GetComponentInParent<Piece025_Object>();
        if (piece025Object == null)
        {
            Debug.LogError("Piece025_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece025Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece025Object != null)
        {
            piece025Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece025Object != null)
        {
            piece025Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece025Object != null)
        {
            piece025Object.Click();
        }
    }
}
