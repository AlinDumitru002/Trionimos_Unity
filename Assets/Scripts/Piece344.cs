using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece344 : MonoBehaviour
{
    private Piece344_Object piece344Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece344Object = GetComponentInParent<Piece344_Object>();
        if (piece344Object == null)
        {
            Debug.LogError("Piece344_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece344Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece344Object != null)
        {
            piece344Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece344Object != null)
        {
            piece344Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece344Object != null)
        {
            piece344Object.Click();
        }
    }
}
