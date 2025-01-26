using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece133_Object : MonoBehaviour, IPieceObject
{
    private int up = 1;
    private int left = 3;
    private int right = 3;
    private int down = 10;
    private int max = 0;
    private bool top_up = true;
    private bool chosen = false;
    private bool isMouseOver = false;
    private bool isRotating = false;
    private int support = 0;
    public float rotationStep = 60f;
    private float currentRotationZ;
    private int rotatePhase = 1;
    private bool available = true;
    private int index = -1;
    private bool changeMaterial = false;



    void Start()
    {
        calculateMax();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isRotating && isMouseOver && TurnSystem.pickingGamePhase() != 4)
        {
            float currentRotationZ = NormalizeAngle(transform.rotation.eulerAngles.z);

            float newRotationZ = currentRotationZ - rotationStep;

            Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, newRotationZ);

            StartCoroutine(RotateCoroutine(targetRotation, 0.5f));
        }
    }

    public bool getAvailable()
    {
        return available;
    }

    public int getSupport()
    {
        return support;
    }
    public void setSupport(int value)
    {
        support = value;
    }

    public void setMaterial()
    {
        if (changeMaterial)
            changeMaterial = false;
        else
            changeMaterial = true;
    }

    public bool getMaterial()
    {
        return changeMaterial;
    }

    public int getIndex()
    {
        return index;
    }

    public void setIndex(int value)
    {
        index = value;
    }

    public int getMax()
    {
        return max;
    }

    public void calculateMax()
    {
        if (up == left && up == right)
            max = up + 15;
        else
        {
            max = up + left + right;
        }
    }

    public bool isPieceChosen()
    {
        return chosen;
    }

    public void getPieceValue(out int tempUp, out int tempDown, out int tempLeft, out int tempRight)
    {
        tempUp = up;
        tempDown = down;
        tempLeft = left;
        tempRight = right;
    }

    public int getRotatePhase()
    {
        return rotatePhase;
    }

    public Vector3 GetCoordinates()
    {
        return transform.position;
    }

    public void setUnavailable()
    {
        available = false;
    }

    public bool mountain()
    {
        return top_up;
    }




    public void OnMouseEnter()
    {
        isMouseOver = true;
    }

    public void OnMouseExit()
    {
        isMouseOver = false;
    }

    public void rotatePiece()
    {
        if (top_up)
        {
            down = right;
            right = up;
            up = 10;
            top_up = false;
        }
        else
        {
            up = left;
            left = down;
            down = 10;
            top_up = true;
        }
        if (rotatePhase == 6)
            rotatePhase = 1;
        else
            rotatePhase++;
    }



    public IEnumerator RotateCoroutine(Quaternion targetRotation, float duration)
    {
        isRotating = true;

        float elapsedTime = 0;
        Quaternion initialRotation = transform.rotation;

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;

        isRotating = false;
    }

    private int k = 10;

    public void resetK()
    {
        k = 10;
    }

    public void Click()
    {
        if (available)
            if (TurnSystem.pickingGamePhase() == 1 && !chosen)
            {
                if (TurnSystem.GetCurrentTurn() == 1)
                    Support1.Instance.TeleportObject(gameObject);
                else if (TurnSystem.GetCurrentTurn() == 2)
                    Support2.Instance.TeleportObject(gameObject);
                else if (TurnSystem.GetCurrentTurn() == 3)
                    Support3.Instance.TeleportObject(gameObject);
                else if (TurnSystem.GetCurrentTurn() == 4)
                    Support4.Instance.TeleportObject(gameObject);
                else
                    Debug.LogWarning("A problem appeared during picking!");
                chosen = true;
                support = TurnSystem.GetCurrentTurn();
                TurnSystem.NextTurn();
            }
            else if (TurnSystem.pickingGamePhase() == 2 && chosen && support == TurnSystem.GetCurrentTurn())
            {
                Commands_game.Instance.TeleportFirstObject(gameObject);
            }
            else if (TurnSystem.pickingGamePhase() == 3 && chosen && support == TurnSystem.GetCurrentTurn())
            {
                Commands_game.Instance.FindPlacesObject(gameObject);
            }
            else if (TurnSystem.pickingGamePhase() == 3 && !chosen)
            {
                if (TurnSystem.getSinglePlayer() && k != 0 && TurnSystem.GetCurrentTurn() > TurnSystem.getReals())
                {
                    k--;
                }
                else
                {
                    int currentPlayer = TurnSystem.GetCurrentTurn();
                    TurnSystem.incrementChances(currentPlayer);
                    if (TurnSystem.getChances(currentPlayer) == 5)
                    {
                        TurnSystem.decrementScore(currentPlayer, 10);
                        TurnSystem.set0Chances(currentPlayer);
                    }
                    if (currentPlayer == 1)
                        Support1.Instance.TeleportObject(gameObject);
                    else if (currentPlayer == 2)
                        Support2.Instance.TeleportObject(gameObject);
                    else if (currentPlayer == 3)
                        Support3.Instance.TeleportObject(gameObject);
                    else if (currentPlayer == 4)
                        Support4.Instance.TeleportObject(gameObject);
                    else
                        Debug.LogWarning("A problem appeared during picking!");
                    chosen = true;
                    support = currentPlayer;
                    if (TurnSystem.getSinglePlayer() && TurnSystem.GetCurrentTurn() > TurnSystem.getReals())
                        StartCoroutine(PauseUpdateForSeconds(3));
                }
            }
    }

    public IEnumerator PauseUpdateForSeconds(float seconds)
    {
        TurnSystem.setPause();

        yield return new WaitForSeconds(seconds);
        TurnSystem.setPause();
    }

    float NormalizeAngle(float angle)
    {
        angle %= 360;
        if (angle > 180)
        {
            angle -= 360;
        }
        return angle;
    }
}