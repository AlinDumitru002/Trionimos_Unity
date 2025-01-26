using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece005 : MonoBehaviour
{
    private Piece005_Object piece005Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece005Object = GetComponentInParent<Piece005_Object>();
        if (piece005Object == null)
        {
            Debug.LogError("Piece005_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece005Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece005Object != null)
        {
            piece005Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece005Object != null)
        {
            piece005Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece005Object != null)
        {
            piece005Object.Click();
        }
    }
}
