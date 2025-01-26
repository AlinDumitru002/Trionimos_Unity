using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece445 : MonoBehaviour
{
    private Piece445_Object piece445Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece445Object = GetComponentInParent<Piece445_Object>();
        if (piece445Object == null)
        {
            Debug.LogError("Piece445_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece445Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece445Object != null)
        {
            piece445Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece445Object != null)
        {
            piece445Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece445Object != null)
        {
            piece445Object.Click();
        }
    }
}
