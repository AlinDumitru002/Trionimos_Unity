using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece115 : MonoBehaviour
{
    private Piece115_Object piece115Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece115Object = GetComponentInParent<Piece115_Object>();
        if (piece115Object == null)
        {
            Debug.LogError("Piece115_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece115Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece115Object != null)
        {
            piece115Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece115Object != null)
        {
            piece115Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece115Object != null)
        {
            piece115Object.Click();
        }
    }
}
