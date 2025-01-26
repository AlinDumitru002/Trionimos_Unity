using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece111 : MonoBehaviour
{
    private Piece111_Object piece111Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece111Object = GetComponentInParent<Piece111_Object>();
        if (piece111Object == null)
        {
            Debug.LogError("Piece111_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece111Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece111Object != null)
        {
            piece111Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece111Object != null)
        {
            piece111Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece111Object != null)
        {
            piece111Object.Click();
        }
    }
}
