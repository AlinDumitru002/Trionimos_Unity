using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece125 : MonoBehaviour
{
    private Piece125_Object piece125Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece125Object = GetComponentInParent<Piece125_Object>();
        if (piece125Object == null)
        {
            Debug.LogError("Piece125_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece125Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece125Object != null)
        {
            piece125Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece125Object != null)
        {
            piece125Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece125Object != null)
        {
            piece125Object.Click();
        }
    }
}
