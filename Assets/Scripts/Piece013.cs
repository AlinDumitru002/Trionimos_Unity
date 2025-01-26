using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece013 : MonoBehaviour
{
    private Piece013_Object piece013Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece013Object = GetComponentInParent<Piece013_Object>();
        if (piece013Object == null)
        {
            Debug.LogError("Piece013_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece013Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece013Object != null)
        {
            piece013Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece013Object != null)
        {
            piece013Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece013Object != null)
        {
            piece013Object.Click();
        }
    }
}
