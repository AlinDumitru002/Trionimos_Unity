using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece000 : MonoBehaviour
{
    private Piece000_Object piece000Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece000Object = GetComponentInParent<Piece000_Object>();
        if (piece000Object == null)
        {
            Debug.LogError("Piece000_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece000Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece000Object != null)
        {
            piece000Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece000Object != null)
        {
            piece000Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece000Object != null)
        {
            piece000Object.Click();
        }
    }
}
