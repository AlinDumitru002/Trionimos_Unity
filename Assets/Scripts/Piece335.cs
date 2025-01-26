using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece335 : MonoBehaviour
{
    private Piece335_Object piece335Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece335Object = GetComponentInParent<Piece335_Object>();
        if (piece335Object == null)
        {
            Debug.LogError("Piece335_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece335Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece335Object != null)
        {
            piece335Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece335Object != null)
        {
            piece335Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece335Object != null)
        {
            piece335Object.Click();
        }
    }
}
