using UnityEngine;
using System.Collections.Generic;

public class Support2 : MonoBehaviour
{
    private static Support2 _instance;

    public static Support2 Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Support2>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("Support2");
                    _instance = obj.AddComponent<Support2>();
                }
            }
            return _instance;
        }
    }

    private List<Vector3> teleportPositions = new List<Vector3>
    {
        new Vector3(11000, 25000,  34000),
        new Vector3( 9000, 25000,  34000),
        new Vector3( 7000, 25000,  34000),
        new Vector3( 5000, 25000,  34000),
        new Vector3( 3000, 25000,  34000),
        new Vector3( 1000, 25000,  34000),
        new Vector3(-1000, 25000,  34000),
        new Vector3(-3000, 25000,  34000),
        new Vector3(-5000, 25000,  34000),
        new Vector3(-7000, 25000,  34000),
        new Vector3(-9000, 25000,  34000),
        new Vector3(-11000, 25000,  34000),
        new Vector3(11000, 22500,  36250),
        new Vector3(9000, 22500,  36250),
        new Vector3(7000, 22500,  36250),
        new Vector3(5000, 22500,  36250),
        new Vector3(3000, 22500,  36250),
        new Vector3(1000, 22500,  36250),
        new Vector3(-1000, 22500,  36250),
        new Vector3(-3000, 22500,  36250),
        new Vector3(-5000, 22500,  36250),
        new Vector3(-7000, 22500,  36250),
        new Vector3(-9000, 22500,  36250),
        new Vector3(-11000, 22500,  36250)
    };

    void Start()
    {
        maxSupport2 = 0;
    }

    private List<bool> positionsAvailable;
    private static int maxSupport2 = 0;
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
            if (max > maxSupport2)
            {
                maxSupport2 = max;
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
            Quaternion newRotation = Quaternion.Euler(37, -180, 0);

            obj.transform.position = newPosition;
            obj.transform.rotation = newRotation;

            positionsAvailable[freePositionIndex] = false;
            pieceComponent.setIndex(freePositionIndex);
            pieceComponent.setSupport(2);

        }
        else
        {
            Debug.LogWarning("No free positions available.");
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
        return maxSupport2;
    }

    public void resetSupport()
    {
        maxSupport2 = 0;
        for (int i = 0; i < 24; i++)
        {
            positionsAvailable[i] = true;
        }
    }

    void Update()
    {
        if (!TurnSystem.getSupport(2))
        {
            resetSupport();
            TurnSystem.setSupport(2);
        }
    }
}