using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece455 : MonoBehaviour
{
    private Piece455_Object piece455Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece455Object = GetComponentInParent<Piece455_Object>();
        if (piece455Object == null)
        {
            Debug.LogError("Piece455_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece455Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece455Object != null)
        {
            piece455Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece455Object != null)
        {
            piece455Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece455Object != null)
        {
            piece455Object.Click();
        }
    }
}
