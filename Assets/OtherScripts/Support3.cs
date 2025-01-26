using UnityEngine;
using System.Collections.Generic;

public class Support3 : MonoBehaviour
{
    private static Support3 _instance;

    public static Support3 Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Support3>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("Support3");
                    _instance = obj.AddComponent<Support3>();
                }
            }
            return _instance;
        }
    }

    private List<Vector3> teleportPositions = new List<Vector3>
    {
        new Vector3(34000, 25000,-11000),
        new Vector3(34000, 25000,-9000),
        new Vector3(34000, 25000,-7000),
        new Vector3(34000, 25000,-5000),
        new Vector3(34000, 25000,-3000),
        new Vector3(34000, 25000,-1000),
        new Vector3(34000, 25000, 1000),
        new Vector3(34000, 25000, 3000),
        new Vector3(34000, 25000, 5000),
        new Vector3(34000, 25000, 7000),
        new Vector3(34000, 25000, 9000),
        new Vector3(34000, 25000, 11000),
        new Vector3(36250, 22500,-11000),
        new Vector3(36250, 22500,-9000),
        new Vector3(36250, 22500,-7000),
        new Vector3(36250, 22500,-5000),
        new Vector3(36250, 22500,-3000),
        new Vector3(36250, 22500,-1000),
        new Vector3(36250, 22500, 1000),
        new Vector3(36250, 22500, 3000),
        new Vector3(36250, 22500, 5000),
        new Vector3(36250, 22500, 7000),
        new Vector3(36250, 22500, 9000),
        new Vector3(36250, 22500,11000),
    };

    void Start()
    {
        maxSupport3 = 0;
    }

    private List<bool> positionsAvailable;
    private static int maxSupport3 = 0;
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
            if (max > maxSupport3)
            {
                maxSupport3 = max;
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
            Quaternion newRotation = Quaternion.Euler(143, 90, 180);

            obj.transform.position = newPosition;
            obj.transform.rotation = newRotation;

            pieceComponent.setIndex(freePositionIndex);
            pieceComponent.setSupport(3);
            positionsAvailable[freePositionIndex] = false;
        }
        else
        {
            Debug.LogWarning("No free teleport positions available.");
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
        return maxSupport3;
    }

    public void resetSupport()
    {
        maxSupport3 = 0;
        for (int i = 0; i < 24; i++)
        {
            positionsAvailable[i] = true;
        }
    }

    void Update()
    {
        if (!TurnSystem.getSupport(3))
        {
            resetSupport();
            TurnSystem.setSupport(3);
        }
    }
}
