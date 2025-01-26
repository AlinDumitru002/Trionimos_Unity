using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece133 : MonoBehaviour
{
    private Piece133_Object piece133Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece133Object = GetComponentInParent<Piece133_Object>();
        if (piece133Object == null)
        {
            Debug.LogError("Piece133_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece133Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece133Object != null)
        {
            piece133Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece133Object != null)
        {
            piece133Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece133Object != null)
        {
            piece133Object.Click();
        }
    }
}
