using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece114 : MonoBehaviour
{
    private Piece114_Object piece114Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece114Object = GetComponentInParent<Piece114_Object>();
        if (piece114Object == null)
        {
            Debug.LogError("Piece114_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece114Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece114Object != null)
        {
            piece114Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece114Object != null)
        {
            piece114Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece114Object != null)
        {
            piece114Object.Click();
        }
    }
}
