using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece122 : MonoBehaviour
{
    private Piece122_Object piece122Object;

    private Material originalMaterial;
    public Material newMaterial;
    private Renderer objectRenderer;


    void Start()
    {
        piece122Object = GetComponentInParent<Piece122_Object>();
        if (piece122Object == null)
        {
            Debug.LogError("Piece122_Object component not found on parent GameObject.");
        }

        objectRenderer = GetComponent<Renderer>();

        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        if (piece122Object.getMaterial())
            objectRenderer.material = newMaterial;
        else
            objectRenderer.material = originalMaterial;
    }

    void OnMouseOver()
    {
        if (piece122Object != null)
        {
            piece122Object.OnMouseEnter();
        }
    }

    void OnMouseExit()
    {
        if (piece122Object != null)
        {
            piece122Object.OnMouseExit();
        }
    }

    void OnMouseDown()
    {
        if (piece122Object != null)
        {
            piece122Object.Click();
        }
    }
}
