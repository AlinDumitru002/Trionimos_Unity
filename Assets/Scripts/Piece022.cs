using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece022 : MonoBehaviour
{
    private Piece022_Object piece022Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece022Object = GetComponentInParent<Piece022_Object>();
        if (piece022Object == null)
        {
            Debug.LogError("Piece022_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece022Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece022Object != null)
        {
            piece022Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece022Object != null)
        {
            piece022Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece022Object != null)
        {
            piece022Object.Click();
        }
    }
}
