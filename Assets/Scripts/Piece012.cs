using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece012 : MonoBehaviour
{
    private Piece012_Object piece012Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece012Object = GetComponentInParent<Piece012_Object>();
        if (piece012Object == null)
        {
            Debug.LogError("Piece012_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece012Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece012Object != null)
        {
            piece012Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece012Object != null)
        {
            piece012Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece012Object != null)
        {
            piece012Object.Click();
        }
    }
}
