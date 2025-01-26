using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece055 : MonoBehaviour
{
    private Piece055_Object piece055Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece055Object = GetComponentInParent<Piece055_Object>();
        if (piece055Object == null)
        {
            Debug.LogError("Piece055_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece055Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece055Object != null)
        {
            piece055Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece055Object != null)
        {
            piece055Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece055Object != null)
        {
            piece055Object.Click();
        }
    }
}
