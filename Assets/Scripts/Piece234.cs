using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece234 : MonoBehaviour
{
    private Piece234_Object piece234Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece234Object = GetComponentInParent<Piece234_Object>();
        if (piece234Object == null)
        {
            Debug.LogError("Piece234_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece234Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece234Object != null)
        {
            piece234Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece234Object != null)
        {
            piece234Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece234Object != null)
        {
            piece234Object.Click();
        }
    }
}
