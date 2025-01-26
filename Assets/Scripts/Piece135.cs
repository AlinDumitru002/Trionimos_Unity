using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece135 : MonoBehaviour
{
    private Piece135_Object piece135Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece135Object = GetComponentInParent<Piece135_Object>();
        if (piece135Object == null)
        {
            Debug.LogError("Piece135_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece135Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece135Object != null)
        {
            piece135Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece135Object != null)
        {
            piece135Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece135Object != null)
        {
            piece135Object.Click();
        }
    }
}
