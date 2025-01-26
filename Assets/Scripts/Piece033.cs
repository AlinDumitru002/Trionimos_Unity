using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece033 : MonoBehaviour
{
    private Piece033_Object piece033Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece033Object = GetComponentInParent<Piece033_Object>();
        if (piece033Object == null)
        {
            Debug.LogError("Piece033_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece033Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece033Object != null)
        {
            piece033Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece033Object != null)
        {
            piece033Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece033Object != null)
        {
            piece033Object.Click();
        }
    }
}
