using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCamera : MonoBehaviour, IMoveCamera
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    public Vector3 position1 = new Vector3(45000, 30000, 0);
    public Vector3 rotation1Euler = new Vector3(145, 90, 180);
    public Vector3 position2 = new Vector3(-50, 50, 50);
    public Vector3 rotation2Euler = new Vector3(0, 90, 0);
    public Vector3 position3 = new Vector3(50, -50, 50);
    public Vector3 rotation3Euler = new Vector3(45, 0, 45);
    public Vector3 position4 = new Vector3(50, 50, -50);

    public Vector3 rotation4Euler = new Vector3(60, 30, 30);
    public Vector3 choosePiecePosition = new Vector3(50, 50, -50);
    public Vector3 rotationChoosePiecePositionEuler = new Vector3(60, 30, 30);
    public Vector3 finalizingPosition = new Vector3(-9000, 36000, 0);
    public Vector3 finalizingRotationEuler = new Vector3(90, 90, 0);

    public float speed = 5f;

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }
    void Update()
    {
        Vector3 targetPosition = initialPosition;
        Quaternion targetRotation = initialRotation;
        if(TurnSystem.pickingGamePhase() == 4)
        {
            targetPosition = finalizingPosition;
            targetRotation = Quaternion.Euler(finalizingRotationEuler);
        }
        else if (Input.GetKey(KeyCode.Alpha1) && TurnSystem.pickingGamePhase()==1)
        {
            targetPosition = position1;
            targetRotation = Quaternion.Euler(rotation1Euler);
        }
        else if (Input.GetKey(KeyCode.Alpha2) && TurnSystem.pickingGamePhase() == 1)
        {
            targetPosition = position2;
            targetRotation = Quaternion.Euler(rotation2Euler);
        }
        else if (Input.GetKey(KeyCode.Alpha3) && TurnSystem.pickingGamePhase() == 1)
        {
            targetPosition = position3;
            targetRotation = Quaternion.Euler(rotation3Euler);
        }
        else if (Input.GetKey(KeyCode.Alpha4) && TurnSystem.pickingGamePhase() == 1)
        {
            targetPosition = position4;
            targetRotation = Quaternion.Euler(rotation4Euler);
        }
        else if (Input.GetKey(KeyCode.A) && TurnSystem.pickingGamePhase() == 3)
        {
            targetPosition = choosePiecePosition;
            targetRotation = Quaternion.Euler(rotationChoosePiecePositionEuler);
        }
        else if (Input.GetKey(KeyCode.S) && TurnSystem.pickingGamePhase() == 3)
        {
            targetPosition = finalizingPosition;
            targetRotation = Quaternion.Euler(finalizingRotationEuler);
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    }

    public void resetFinalizingPosition()
    {
         finalizingPosition = new Vector3(-9000, 36000, 0);
    }

    public void increaseRange()
    {
        finalizingPosition.y += 3000;
    }

    public void PositionSupport1()
    {
        initialPosition = position1;
        initialRotation = Quaternion.Euler(rotation1Euler);
        transform.position = position1;
        transform.rotation = Quaternion.Euler(rotation1Euler);
    }

    public void PositionSupport2()
    {
        initialPosition = position2;
        initialRotation = Quaternion.Euler(rotation2Euler);
        transform.position = position2;
        transform.rotation = Quaternion.Euler(rotation2Euler);
    }

    public void PositionSupport3()
    {
        initialPosition = position3;
        initialRotation = Quaternion.Euler(rotation3Euler);
        transform.position = position3;
        transform.rotation = Quaternion.Euler(rotation3Euler);
    }

    public void PositionSupport4()
    {
        initialPosition = position4;
        initialRotation = Quaternion.Euler(rotation4Euler);
        transform.position = position4;
        transform.rotation = Quaternion.Euler(rotation4Euler);
    }

    public void PositionChoodePieces()
    {
        transform.position = choosePiecePosition;
        transform.rotation = Quaternion.Euler(rotationChoosePiecePositionEuler);
    }

    public void PositionChoosePiecePosition()
    {
        transform.position = finalizingPosition;
        transform.rotation = Quaternion.Euler(finalizingRotationEuler);
    }
}
