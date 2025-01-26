using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece113 : MonoBehaviour
{
    private Piece113_Object piece113Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece113Object = GetComponentInParent<Piece113_Object>();
        if (piece113Object == null)
        {
            Debug.LogError("Piece111_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece113Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece113Object != null)
        {
            piece113Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece113Object != null)
        {
            piece113Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece113Object != null)
        {
            piece113Object.Click();
        }
    }
}
