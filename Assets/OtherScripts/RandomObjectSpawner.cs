using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public Vector3 startPosition = new Vector3(26000f, 22033.15f, 14000f);
    private int piecesToSpawn = 56;
    private int piecesPerRow = 14;
    private float xOffset = -2500f;
    private float zOffset = -2000f;
    private List<GameObject> availablePiecePrefabs = new List<GameObject>();
    private List<GameObject> spawnedObjects = new List<GameObject>();

    void Start()
    {
        LoadAvailablePiecePrefabs();
        SpawnMultipleObjects(piecesToSpawn);
    }

    void Update()
    {
        if (!TurnSystem.getTable())
        {
            DeleteAllSpawnedObjects();
            TurnSystem.setTable();
            LoadAvailablePiecePrefabs();
            SpawnMultipleObjects(piecesToSpawn);
        }
        for (int i = 0; i < 5; i++)
        {
            if (TurnSystem.getScore(i) >= 400)
            {
                if (TurnSystem.getNumberPlayers() == 2 && i == 3)
                    Debug.Log("Player 2 won!");
                else
                    Debug.Log("Player " + i + " won!");
                DeleteAllSpawnedObjects();
            }
        }
    }

    void LoadAvailablePiecePrefabs()
    {
        GameObject[] prefabs = Resources.LoadAll<GameObject>("Pieces");
        availablePiecePrefabs.AddRange(prefabs);
    }

    public void SpawnMultipleObjects(int numberOfPieces)
    {
        Vector3 spawnPosition = startPosition;

        for (int i = 0; i < numberOfPieces; i++)
        {
            if (availablePiecePrefabs.Count == 0)
            {
                Debug.LogWarning("Nu mai există fișiere disponibile pentru spawnare.");
                break;
            }

            int randomIndex = Random.Range(0, availablePiecePrefabs.Count);
            GameObject piecePrefab = availablePiecePrefabs[randomIndex];

            if (piecePrefab != null)
            {
                GameObject spawnedObject = Instantiate(piecePrefab, spawnPosition, Quaternion.identity);
                spawnedObject.transform.rotation = Quaternion.Euler(-90f, 0f, 180f);

                spawnedObjects.Add(spawnedObject);

                availablePiecePrefabs.RemoveAt(randomIndex);
            }
            else
            {
                Debug.LogError("Failed to load prefab: " + piecePrefab.name);
            }

            spawnPosition.z += zOffset;

            if ((i + 1) % piecesPerRow == 0)
            {
                spawnPosition.z = startPosition.z;
                spawnPosition.x += xOffset;
            }
        }
    }

    public void DeleteAllSpawnedObjects()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            Destroy(obj);
        }
        spawnedObjects.Clear();
        Debug.Log("All spawned objects have been deleted.");
    }
}
