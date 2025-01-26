using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece235 : MonoBehaviour
{
    private Piece235_Object piece235Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece235Object = GetComponentInParent<Piece235_Object>();
        if (piece235Object == null)
        {
            Debug.LogError("Piece235_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece235Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece235Object != null)
        {
            piece235Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece235Object != null)
        {
            piece235Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece235Object != null)
        {
            piece235Object.Click();
        }
    }
}
