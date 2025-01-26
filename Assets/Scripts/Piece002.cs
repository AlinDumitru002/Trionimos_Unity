using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece002 : MonoBehaviour
{
    private Piece002_Object piece002Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece002Object = GetComponentInParent<Piece002_Object>();
        if (piece002Object == null)
        {
            Debug.LogError("Piece002_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece002Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece002Object != null)
        {
            piece002Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece002Object != null)
        {
            piece002Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece002Object != null)
        {
            piece002Object.Click();
        }
    }
}
