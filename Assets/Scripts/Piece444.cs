using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece444 : MonoBehaviour
{
    private Piece444_Object piece444Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece444Object = GetComponentInParent<Piece444_Object>();
        if (piece444Object == null)
        {
            Debug.LogError("Piece444_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece444Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece444Object != null)
        {
            piece444Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece444Object != null)
        {
            piece444Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece444Object != null)
        {
            piece444Object.Click();
        }
    }
}
