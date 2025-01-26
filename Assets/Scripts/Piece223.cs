using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece223 : MonoBehaviour
{
    private Piece223_Object piece223Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece223Object = GetComponentInParent<Piece223_Object>();
        if (piece223Object == null)
        {
            Debug.LogError("Piece223_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece223Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece223Object != null)
        {
            piece223Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece223Object != null)
        {
            piece223Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece223Object != null)
        {
            piece223Object.Click();
        }
    }
}
