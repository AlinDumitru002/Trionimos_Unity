using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece123 : MonoBehaviour
{
    private Piece123_Object piece123Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece123Object = GetComponentInParent<Piece123_Object>();
        if (piece123Object == null)
        {
            Debug.LogError("Piece123_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece123Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece123Object != null)
        {
            piece123Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece123Object != null)
        {
            piece123Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece123Object != null)
        {
            piece123Object.Click();
        }
    }
}
