using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece112 : MonoBehaviour
{
    private Piece112_Object piece112Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece112Object = GetComponentInParent<Piece112_Object>();
        if (piece112Object == null)
        {
            Debug.LogError("Piece112_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece112Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece112Object != null)
        {
            piece112Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece112Object != null)
        {
            piece112Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece112Object != null)
        {
            piece112Object.Click();
        }
    }
}
