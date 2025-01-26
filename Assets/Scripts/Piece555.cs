using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece555 : MonoBehaviour
{
    private Piece555_Object piece555Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece555Object = GetComponentInParent<Piece555_Object>();
        if (piece555Object == null)
        {
            Debug.LogError("Piece555_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece555Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece555Object != null)
        {
            piece555Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece555Object != null)
        {
            piece555Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece555Object != null)
        {
            piece555Object.Click();
        }
    }
}
