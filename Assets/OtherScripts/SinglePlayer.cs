using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewBehaviourScript : MonoBehaviour
{
    private static bool singlePlayer;
    public float clickInterval = 1f;
    private GameObject[] clickableObjects;
    void Start()
    {
        clickableObjects = GameObject.FindGameObjectsWithTag("Clickable");
    }

    void Update()
    {
        if (TurnSystem.getSinglePlayer())
        {
            singlePlayer = true;
        }

        if (!TurnSystem.getPause() && TurnSystem.GetCurrentTurn() > TurnSystem.getReals())
        {
            if (TurnSystem.GetCurrentTurn() > TurnSystem.getReals() && singlePlayer)
            {
                if (TurnSystem.pickingGamePhase() == 1 || TurnSystem.pickingGamePhase() == 2)
                {
                    ClickRandomObject();
                }
                else if (TurnSystem.pickingGamePhase() == 3)
                {
                    int randomIndex = Random.Range(0, clickableObjects.Length);
                    if (randomIndex == 1)
                        TurnSystem.HandlePassPress();
                    if (!TurnSystem.getPassAprovved())
                    {
                        ClickRandomObject();
                    }
                }
                else { }
            }
        }
    }

    public void ClickRandomObject()
    {
        clickableObjects = GameObject.FindGameObjectsWithTag("Clickable");

        if (clickableObjects.Length > 0)
        {
            int randomIndex = Random.Range(0, clickableObjects.Length);
            GameObject randomObject = clickableObjects[randomIndex];

            if (randomObject != null && randomObject.activeInHierarchy)
            {
                Collider collider = randomObject.GetComponent<Collider>();
                if (collider != null)
                {
                    randomObject.SendMessage("OnMouseDown");
                }
            }
            else
            {
                Debug.Log("Object " + randomObject.name + " no longer exists or is inactive.");
            }
        }
    }
}