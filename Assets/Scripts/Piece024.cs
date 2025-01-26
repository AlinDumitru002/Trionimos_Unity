using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece024 : MonoBehaviour
{
    private Piece024_Object piece024Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece024Object = GetComponentInParent<Piece024_Object>();
        if (piece024Object == null)
        {
            Debug.LogError("Piece024_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece024Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece024Object != null)
        {
            piece024Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece024Object != null)
        {
            piece024Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece024Object != null)
        {
            piece024Object.Click();
        }
    }
}
