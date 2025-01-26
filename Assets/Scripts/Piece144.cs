using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece144 : MonoBehaviour
{
    private Piece144_Object piece144Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece144Object = GetComponentInParent<Piece144_Object>();
        if (piece144Object == null)
        {
            Debug.LogError("Piece144_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece144Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece144Object != null)
        {
            piece144Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece144Object != null)
        {
            piece144Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece144Object != null)
        {
            piece144Object.Click();
        }
    }
}
