using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece014 : MonoBehaviour
{
    private Piece014_Object piece014Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece014Object = GetComponentInParent<Piece014_Object>();
        if (piece014Object == null)
        {
            Debug.LogError("Piece014_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece014Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece014Object != null)
        {
            piece014Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece014Object != null)
        {
            piece014Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece014Object != null)
        {
            piece014Object.Click();
        }
    }
}
