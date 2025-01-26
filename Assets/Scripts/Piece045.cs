using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece045 : MonoBehaviour
{
    private Piece045_Object piece045Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece045Object = GetComponentInParent<Piece045_Object>();
        if (piece045Object == null)
        {
            Debug.LogError("Piece045_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece045Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece045Object != null)
        {
            piece045Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece045Object != null)
        {
            piece045Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece045Object != null)
        {
            piece045Object.Click();
        }
    }
}
