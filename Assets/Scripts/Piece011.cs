using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece011 : MonoBehaviour
{
    private Piece011_Object piece011Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece011Object = GetComponentInParent<Piece011_Object>();
        if (piece011Object == null)
        {
            Debug.LogError("Piece011_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece011Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece011Object != null)
        {
            piece011Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece011Object != null)
        {
            piece011Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece011Object != null)
        {
            piece011Object.Click();
        }
    }
}
