using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece245 : MonoBehaviour
{
    private Piece245_Object piece245Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece245Object = GetComponentInParent<Piece245_Object>();
        if (piece245Object == null)
        {
            Debug.LogError("Piece245_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece245Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece245Object != null)
        {
            piece245Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece245Object != null)
        {
            piece245Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece245Object != null)
        {
            piece245Object.Click();
        }
    }
}
