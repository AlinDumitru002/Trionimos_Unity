using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece255 : MonoBehaviour
{
    private Piece255_Object piece255Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece255Object = GetComponentInParent<Piece255_Object>();
        if (piece255Object == null)
        {
            Debug.LogError("Piece255_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece255Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece255Object != null)
        {
            piece255Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece255Object != null)
        {
            piece255Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece255Object != null)
        {
            piece255Object.Click();
        }
    }
}
