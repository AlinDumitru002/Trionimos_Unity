using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece124 : MonoBehaviour
{
    private Piece124_Object piece124Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece124Object = GetComponentInParent<Piece124_Object>();
        if (piece124Object == null)
        {
            Debug.LogError("Piece124_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece124Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece124Object != null)
        {
            piece124Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece124Object != null)
        {
            piece124Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece124Object != null)
        {
            piece124Object.Click();
        }
    }
}
