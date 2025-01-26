using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece015 : MonoBehaviour
{
    private Piece015_Object piece015Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece015Object = GetComponentInParent<Piece015_Object>();
        if (piece015Object == null)
        {
            Debug.LogError("Piece015_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece015Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece015Object != null)
        {
            piece015Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece015Object != null)
        {
            piece015Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece015Object != null)
        {
            piece015Object.Click();
        }
    }
}
