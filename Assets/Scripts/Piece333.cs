using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece333 : MonoBehaviour
{
    private Piece333_Object piece333Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece333Object = GetComponentInParent<Piece333_Object>();
        if (piece333Object == null)
        {
            Debug.LogError("Piece333_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece333Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece333Object != null)
        {
            piece333Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece333Object != null)
        {
            piece333Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece333Object != null)
        {
            piece333Object.Click();
        }
    }
}
