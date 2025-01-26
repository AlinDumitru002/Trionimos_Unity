using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece345 : MonoBehaviour
{
    private Piece345_Object piece345Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece345Object = GetComponentInParent<Piece345_Object>();
        if (piece345Object == null)
        {
            Debug.LogError("Piece345_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece345Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece345Object != null)
        {
            piece345Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece345Object != null)
        {
            piece345Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece345Object != null)
        {
            piece345Object.Click();
        }
    }
}
