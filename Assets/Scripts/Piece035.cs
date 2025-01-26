using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece035 : MonoBehaviour
{
    private Piece035_Object piece035Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece035Object = GetComponentInParent<Piece035_Object>();
        if (piece035Object == null)
        {
            Debug.LogError("Piece035_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece035Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece035Object != null)
        {
            piece035Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece035Object != null)
        {
            piece035Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece035Object != null)
        {
            piece035Object.Click();
        }
    }
}
