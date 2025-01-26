using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece003 : MonoBehaviour
{
    private Piece003_Object piece003Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece003Object = GetComponentInParent<Piece003_Object>();
        if (piece003Object == null)
        {
            Debug.LogError("Piece003_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece003Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece003Object != null)
        {
            piece003Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece003Object != null)
        {
            piece003Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece003Object != null)
        {
            piece003Object.Click();
        }
    }
}
