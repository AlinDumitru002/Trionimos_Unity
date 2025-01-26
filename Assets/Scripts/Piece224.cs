using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece224 : MonoBehaviour
{
    private Piece224_Object piece224Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece224Object = GetComponentInParent<Piece224_Object>();
        if (piece224Object == null)
        {
            Debug.LogError("Piece224_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece224Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece224Object != null)
        {
            piece224Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece224Object != null)
        {
            piece224Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece224Object != null)
        {
            piece224Object.Click();
        }
    }
}
