using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece004 : MonoBehaviour
{
    private Piece004_Object piece004Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece004Object = GetComponentInParent<Piece004_Object>();
        if (piece004Object == null)
        {
            Debug.LogError("Piece004_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece004Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece004Object != null)
        {
            piece004Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece004Object != null)
        {
            piece004Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece004Object != null)
        {
            piece004Object.Click();
        }
    }
}
