using UnityEngine;
using System.Collections.Generic;

public class Support4 : MonoBehaviour
{
    private static Support4 _instance;

    public static Support4 Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Support4>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("Support4");
                    _instance = obj.AddComponent<Support4>();
                }
            }
            return _instance;
        }
    }

    private List<Vector3> teleportPositions = new List<Vector3>
    {
        new Vector3(-11000, 25000,  -34000),
        new Vector3( -9000, 25000,  -34000),
        new Vector3( -7000, 25000,  -34000),
        new Vector3( -5000, 25000,  -34000),
        new Vector3( -3000, 25000,  -34000),
        new Vector3( -1000, 25000,  -34000),
        new Vector3(1000, 25000,  -34000),
        new Vector3(3000, 25000,  -34000),
        new Vector3(5000, 25000,  -34000),
        new Vector3(7000, 25000,  -34000),
        new Vector3(9000, 25000,  -34000),
        new Vector3(11000, 25000,  -34000),
        new Vector3(-11000, 22500,  -36250),
        new Vector3(-9000, 22500,  -36250),
        new Vector3(-7000, 22500,  -36250),
        new Vector3(-5000, 22500,  -36250),
        new Vector3(-3000, 22500,  -36250),
        new Vector3(-1000, 22500,  -36250),
        new Vector3(1000, 22500,  -36250),
        new Vector3(3000, 22500,  -36250),
        new Vector3(5000, 22500,  -36250),
        new Vector3(7000, 22500,  -36250),
        new Vector3(9000, 22500,  -36250),
        new Vector3(11000, 22500,  -36250)
    };

    void Start()
    {
        maxSupport4 = 0;
    }

    private List<bool> positionsAvailable;
    private static int maxSupport4 = 0;
    private void Awake()
    {
        positionsAvailable = new List<bool>(new bool[teleportPositions.Count]);
        for (int i = 0; i < positionsAvailable.Count; i++)
        {
            positionsAvailable[i] = true;
        }
    }

    public void TeleportObject(GameObject obj)
    {
        IPieceObject pieceComponent = obj.GetComponent<IPieceObject>();
        if (pieceComponent != null)
        {
            int max = pieceComponent.getMax();
            if (max > maxSupport4)
            {
                maxSupport4 = max;
            }
        }
        else
        {
            Debug.LogWarning("The object does not implement IPieceObject.");
        }

        int freePositionIndex = FindFreePosition();

        if (freePositionIndex != -1)
        {
            Vector3 newPosition = teleportPositions[freePositionIndex];
            Quaternion newRotation = Quaternion.Euler(37, 0, 0);

            obj.transform.position = newPosition;
            obj.transform.rotation = newRotation;

            pieceComponent.setIndex(freePositionIndex);
            pieceComponent.setSupport(4);
            positionsAvailable[freePositionIndex] = false;
        }
    }

    private int FindFreePosition()
    {
        for (int i = 0; i < positionsAvailable.Count; i++)
        {
            if (positionsAvailable[i])
            {
                return i;
            }
        }
        return -1;
    }

    public bool isSupportCleared()
    {
        foreach (bool available in positionsAvailable)
        {
            if (!available)
            {
                return false;
            }
        }
        return true;
    }

    public void SetPositionFree(int index)
    {
         positionsAvailable[index] = true;
    }

    public static int getMaxim()
    {
        return maxSupport4;
    }

    public void resetSupport()
    {
        maxSupport4 = 0;
        for (int i = 0; i < 24; i++)
        {
            positionsAvailable[i] = true;
        }
    }

    void Update()
    {
        if (!TurnSystem.getSupport(4))
        {
            resetSupport();
            TurnSystem.setSupport(4);
        }
    }
}