using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece225 : MonoBehaviour
{
    private Piece225_Object piece225Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece225Object = GetComponentInParent<Piece225_Object>();
        if (piece225Object == null)
        {
            Debug.LogError("Piece225_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece225Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece225Object != null)
        {
            piece225Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece225Object != null)
        {
            piece225Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece225Object != null)
        {
            piece225Object.Click();
        }
    }
}
