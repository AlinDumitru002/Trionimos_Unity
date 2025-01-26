using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece034 : MonoBehaviour
{
    private Piece034_Object piece034Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece034Object = GetComponentInParent<Piece034_Object>();
        if (piece034Object == null)
        {
            Debug.LogError("Piece034_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece034Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece034Object != null)
        {
            piece034Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece034Object != null)
        {
            piece034Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece034Object != null)
        {
            piece034Object.Click();
        }
    }
}
