using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece001 : MonoBehaviour
{
    private Piece001_Object piece001Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece001Object = GetComponentInParent<Piece001_Object>();
        if (piece001Object == null)
        {
            Debug.LogError("Piece001_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece001Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece001Object != null)
        {
            piece001Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece001Object != null)
        {
            piece001Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece001Object != null)
        {
            piece001Object.Click();
        }
    }
}
