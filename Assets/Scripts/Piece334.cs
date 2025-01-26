using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece334 : MonoBehaviour
{
    private Piece334_Object piece334Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece334Object = GetComponentInParent<Piece334_Object>();
        if (piece334Object == null)
        {
            Debug.LogError("Piece334_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece334Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece334Object != null)
        {
            piece334Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece334Object != null)
        {
            piece334Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece334Object != null)
        {
            piece334Object.Click();
        }
    }
}
