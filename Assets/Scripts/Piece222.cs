using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece222 : MonoBehaviour
{
    private Piece222_Object piece222Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece222Object = GetComponentInParent<Piece222_Object>();
        if (piece222Object == null)
        {
            Debug.LogError("Piece222_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece222Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece222Object != null)
        {
            piece222Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece222Object != null)
        {
            piece222Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece222Object != null)
        {
            piece222Object.Click();
        }
    }
}
