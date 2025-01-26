using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece233 : MonoBehaviour
{
    private Piece233_Object piece233Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece233Object = GetComponentInParent<Piece233_Object>();
        if (piece233Object == null)
        {
            Debug.LogError("Piece233_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece233Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece233Object != null)
        {
            piece233Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece233Object != null)
        {
            piece233Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece233Object != null)
        {
            piece233Object.Click();
        }
    }
}
