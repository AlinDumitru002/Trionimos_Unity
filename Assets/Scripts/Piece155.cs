using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece155 : MonoBehaviour
{
    private Piece155_Object piece155Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece155Object = GetComponentInParent<Piece155_Object>();
        if (piece155Object == null)
        {
            Debug.LogError("Piece155_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece155Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece155Object != null)
        {
            piece155Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece155Object != null)
        {
            piece155Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece155Object != null)
        {
            piece155Object.Click();
        }
    }
}
