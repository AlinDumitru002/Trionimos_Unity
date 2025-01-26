using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece044 : MonoBehaviour
{
    private Piece044_Object piece044Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece044Object = GetComponentInParent<Piece044_Object>();
        if (piece044Object == null)
        {
            Debug.LogError("Piece044_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece044Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece044Object != null)
        {
            piece044Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece044Object != null)
        {
            piece044Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece044Object != null)
        {
            piece044Object.Click();
        }
    }
}
