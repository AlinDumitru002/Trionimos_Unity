using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece145 : MonoBehaviour
{
    private Piece145_Object piece145Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece145Object = GetComponentInParent<Piece145_Object>();
        if (piece145Object == null)
        {
            Debug.LogError("Piece145_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece145Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece145Object != null)
        {
            piece145Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece145Object != null)
        {
            piece145Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece145Object != null)
        {
            piece145Object.Click();
        }
    }
}
