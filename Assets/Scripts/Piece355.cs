using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece355 : MonoBehaviour
{
    private Piece355_Object piece355Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece355Object = GetComponentInParent<Piece355_Object>();
        if (piece355Object == null)
        {
            Debug.LogError("Piece355_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece355Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece355Object != null)
        {
            piece355Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece355Object != null)
        {
            piece355Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece355Object != null)
        {
            piece355Object.Click();
        }
    }
}
