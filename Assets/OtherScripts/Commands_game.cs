using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commands_game : MonoBehaviour
{
    private static Commands_game _instance;

    public static Commands_game Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Commands_game>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("Commands_game");
                    _instance = obj.AddComponent<Commands_game>();
                }
            }
            return _instance;
        }
    }

    public struct MatrixElement
    {
        public bool occupied;
        public int up;
        public int down;
        public int left;
        public int right;
        public Vector3 coordinates;

        public MatrixElement(Vector3 coord)
        {
            occupied = false;
            up = 10;
            down = 10;
            left = 10;
            right = 10;
            coordinates = coord;
        }
    }

    public struct PositionWithPhase
    {
        public Vector2Int position;
        public int phase;

        public PositionWithPhase(Vector2Int pos, int val)
        {
            position = pos;
            phase = val;
        }
    }

    private MatrixElement[,] matrix;
    public int rows = 30;
    public int columns = 48;

    private int maxI = 10;
    private int maxJ = 24;

    private Quaternion phase1 = Quaternion.Euler(90, 90, 0);
    private Quaternion phase2 = Quaternion.Euler(90, 180, 30);
    private Quaternion phase3 = Quaternion.Euler(90, 180, -30);
    private Quaternion phase4 = Quaternion.Euler(90, 180, -90);
    private Quaternion phase5 = Quaternion.Euler(90, 0, 30);
    private Quaternion phase6 = Quaternion.Euler(90, 180, 150);

    private int tempUp;
    private int tempDown;
    private int tempLeft;
    private int tempRight;

    private List<PositionWithPhase> potentialPositions = new List<PositionWithPhase>();
    private int currentIndex = -1;
    private GameObject currentObject;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        matrix = new MatrixElement[rows, columns];

        float startX = 8500f;
        float startZ = 24000f;
        float y = 21250f;

        for (int i = 0; i < rows; i++)
        {
            float x = startX - i * 1650f;
            float z = startZ;

            for (int j = 0; j < columns; j++)
            {
                if ((i + j) % 2 == 0)
                {
                    x -= 500f;
                }
                Vector3 coord = new Vector3(x, y, z);
                matrix[i, j] = new MatrixElement(coord);
                z -= 1000f;
                if ((i + j) % 2 == 0)
                {
                    x += 500f;
                }
            }

        }
    }

    void PrintMatrixCoordinates()
    {
        Debug.Log("Matrix Coordinates:");

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Debug.Log($"Matrix[{i}, {j}] coordinates: {matrix[i, j].coordinates}");
            }
        }
    }

    public void ClearMatrix()
    {

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j].occupied = false;
                matrix[i, j].up = 10;
                matrix[i, j].down = 10;
                matrix[i, j].left = 10;
                matrix[i, j].right = 10;
            }
        }
        maxI = 0;
        maxJ = 0;
    }

    public void TeleportFirstObject(GameObject obj)
    {
        IPieceObject pieceComponent = obj.GetComponent<IPieceObject>();
        if (pieceComponent != null)
        {
            int up, down, left, right;
            pieceComponent.getPieceValue(out up, out down, out left, out right);

            int row = 10;
            int col = 24;

            int phase = pieceComponent.getRotatePhase();
            if (phase % 2 != (row + col) % 2)
            {
                matrix[row, col].up = up;
                matrix[row, col].down = down;
                matrix[row, col].left = left;
                matrix[row, col].right = right;
                matrix[row, col].occupied = true;
                pieceComponent.setUnavailable();

                int currentPlayer = TurnSystem.GetCurrentTurn();
                TurnSystem.incrementScore(currentPlayer, up + down + left + right - 10);
                obj.transform.position = matrix[row, col].coordinates;
                obj.transform.rotation = GetRotationByPhase(phase);
                if (currentPlayer == 1)
                {
                    int position = pieceComponent.getIndex();
                    Support1.Instance.SetPositionFree(position);
                }
                else if (currentPlayer == 2)
                {
                    int position = pieceComponent.getIndex();
                    Support2.Instance.SetPositionFree(position);
                }
                else if (currentPlayer == 3)
                {
                    int position = pieceComponent.getIndex();
                    Support3.Instance.SetPositionFree(position);
                }
                else if (currentPlayer == 4)
                {
                    int position = pieceComponent.getIndex();
                    Support4.Instance.SetPositionFree(position);
                }
                TurnSystem.changePickingPhase();
                TurnSystem.NextTurn2();
            }
        }
        else
        {
            Debug.LogWarning("The object does not implement IPieceObject.");
        }
    }

    public Material originalMaterial;
    public Material newMaterial;

    public void FindPlacesObject(GameObject obj)
    {
        IPieceObject pieceComponent = obj.GetComponent<IPieceObject>();
        if (pieceComponent != null)
        {
            potentialPositions.Clear();
            currentIndex = -1;
            currentObject = obj;
            originalPosition = obj.transform.position;
            originalRotation = obj.transform.rotation;

            int up, down, left, right;
            pieceComponent.getPieceValue(out up, out down, out left, out right);
            tempUp = up;
            tempDown = down;
            tempLeft = left;
            tempRight = right;
            for (int p = 1; p < 7; p++)
            {
                for (int i = 2; i < rows - 2; i++)
                {
                    for (int j = 2; j < columns - 2; j++)
                    {
                        if (!matrix[i, j].occupied)
                        {
                            if (p % 2 != (i + j) % 2)
                            {
                                if (p % 2 == 0 && (matrix[i - 1, j].occupied == true || matrix[i, j - 1].occupied == true || matrix[i, j + 1].occupied == true) &&
                                                (tempLeft == matrix[i - 1, j].left || matrix[i - 1, j].left == 10) &&
                                                (tempLeft == matrix[i, j - 1].up || matrix[i, j - 1].up == 10) &&
                                                (tempLeft == matrix[i - 1, j - 2].right || matrix[i - 1, j - 2].right == 10) &&
                                                (tempLeft == matrix[i, j - 2].right || matrix[i, j - 2].right == 10) &&
                                                (tempLeft == matrix[i - 1, j - 1].down || matrix[i - 1, j - 1].down == 10) &&
                                                (tempDown == matrix[i, j - 1].right || matrix[i, j - 1].right == 10) &&
                                                (tempDown == matrix[i, j + 1].left || matrix[i, j + 1].left == 10) &&
                                                (tempDown == matrix[i + 1, j - 1].right || matrix[i + 1, j - 1].right == 10) &&
                                                (tempDown == matrix[i + 1, j].up || matrix[i + 1, j].up == 10) &&
                                                (tempDown == matrix[i + 1, j + 1].left || matrix[i + 1, j + 1].left == 10) &&
                                                (tempRight == matrix[i, j + 1].up || matrix[i, j + 1].up == 10) &&
                                                (tempRight == matrix[i - 1, j].right || matrix[i - 1, j].right == 10) &&
                                                (tempRight == matrix[i - 1, j + 1].down || matrix[i - 1, j + 1].down == 10) &&
                                                (tempRight == matrix[i - 1, j + 2].left || matrix[i - 1, j + 2].left == 10) &&
                                                (tempRight == matrix[i, j + 2].left || matrix[i, j + 2].left == 10))

                                    potentialPositions.Add(new PositionWithPhase(new Vector2Int(i, j), p));
                                else if (p % 2 == 1 && (matrix[i + 1, j].occupied == true || matrix[i, j - 1].occupied == true || matrix[i, j + 1].occupied == true) &&
                                                (tempLeft == matrix[i + 1, j].left || matrix[i + 1, j].left == 10) &&
                                                (tempLeft == matrix[i, j - 1].down || matrix[i, j - 1].down == 10) &&
                                                (tempLeft == matrix[i, j - 2].right || matrix[i, j - 2].right == 10) &&
                                                (tempLeft == matrix[i + 1, j - 1].up || matrix[i + 1, j - 1].up == 10) &&
                                                (tempLeft == matrix[i + 1, j - 2].right || matrix[i + 1, j - 2].right == 10) &&
                                                (tempUp == matrix[i, j - 1].right || matrix[i, j - 1].right == 10) &&
                                                (tempUp == matrix[i, j + 1].left || matrix[i, j + 1].left == 10) &&
                                                (tempUp == matrix[i - 1, j - 1].right || matrix[i - 1, j - 1].right == 10) &&
                                                (tempUp == matrix[i - 1, j].down || matrix[i - 1, j].down == 10) &&
                                                (tempUp == matrix[i - 1, j + 1].left || matrix[i - 1, j + 1].left == 10) &&
                                                (tempRight == matrix[i, j + 1].down || matrix[i, j + 1].down == 10) &&
                                                (tempRight == matrix[i + 1, j].right || matrix[i + 1, j].right == 10) &&
                                                (tempRight == matrix[i, j + 2].left || matrix[i, j + 2].left == 10) &&
                                                (tempRight == matrix[i + 1, j + 1].up || matrix[i + 1, j + 1].up == 10) &&
                                                (tempRight == matrix[i + 1, j + 2].left || matrix[i + 1, j + 2].left == 10))

                                    potentialPositions.Add(new PositionWithPhase(new Vector2Int(i, j), p));
                            }
                        }
                    }
                }
                pieceComponent.rotatePiece();
                pieceComponent.getPieceValue(out tempUp, out tempDown, out tempLeft, out tempRight);
            }
            if (potentialPositions.Count > 0)
            {
                if (TurnSystem.getSinglePlayer() && TurnSystem.GetCurrentTurn() > TurnSystem.getReals())
                {
                    currentIndex = (currentIndex + 1) % potentialPositions.Count;
                    TeleportToCurrentIndex(obj, up, down, left, right);
                    pieceComponent.setMaterial();
                    FinalizeTeleport(currentObject);
                    TurnSystem.NextTurn2();
                }
                else
                {
                    currentIndex = 0;
                    TeleportToCurrentIndex(obj, up, down, left, right);
                    pieceComponent.setMaterial();
                    TurnSystem.startFindingPosition();
                }
            }
        }
        else
        {
            Debug.LogWarning("The object does not implement IPieceObject.");
        }
    }


    void Update()
    {
        if (currentObject != null && potentialPositions.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                currentIndex = (currentIndex + 1) % potentialPositions.Count;
                TeleportToCurrentIndex(currentObject);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                currentIndex = (currentIndex - 1 + potentialPositions.Count) % potentialPositions.Count;
                TeleportToCurrentIndex(currentObject);
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                FinalizeTeleport(currentObject);
                TurnSystem.NextTurn2();
            }
            else if (Input.GetKeyDown(KeyCode.Backspace))
            {
                CancelTeleport(currentObject);
            }
        }
        if (!TurnSystem.getMatrix())
        {
            ClearMatrix();
            TurnSystem.setMatrix();
            IMoveCamera cameraMover = FindObjectOfType<CustomCamera>() as IMoveCamera;
            cameraMover.resetFinalizingPosition();
        }
    }

    public IEnumerator PauseUpdateForSeconds(float seconds)
    {
        TurnSystem.setPause();

        yield return new WaitForSeconds(seconds);
        TurnSystem.setPause();
    }

    private void TeleportToCurrentIndex(GameObject obj, int up = 0, int down = 0, int left = 0, int right = 0)
    {
        PositionWithPhase posWithPhase = potentialPositions[currentIndex];
        Vector2Int pos = posWithPhase.position;
        int phase = posWithPhase.phase;

        obj.transform.position = matrix[pos.x, pos.y].coordinates;
        obj.transform.rotation = GetRotationByPhase(phase);
        Renderer objRenderer = obj.GetComponent<MeshRenderer>();
        objRenderer.material = newMaterial;
    }


    private void FinalizeTeleport(GameObject obj, int up = 0, int down = 0, int left = 0, int right = 0)
    {
        IPieceObject pieceComponent = obj.GetComponent<IPieceObject>();
        if (pieceComponent != null)
        {
            if (currentIndex >= 0 && currentIndex < potentialPositions.Count)
            {
                Vector2Int pos = potentialPositions[currentIndex].position;
                int tempPhase = potentialPositions[currentIndex].phase;
                for (int i = 1; i < tempPhase; i++)
                {
                    pieceComponent.rotatePiece();
                }
                pieceComponent.getPieceValue(out up, out down, out left, out right);
                matrix[pos.x, pos.y].up = up;
                matrix[pos.x, pos.y].down = down;
                matrix[pos.x, pos.y].left = left;
                matrix[pos.x, pos.y].right = right;
                matrix[pos.x, pos.y].occupied = true;
                matrix[pos.x, pos.y].occupied = true;
                pieceComponent.setMaterial();
                int currentPlayer = TurnSystem.GetCurrentTurn();
                TurnSystem.incrementScore(currentPlayer, up + down + left + right - 10);
                CheckRectangleFormed(pos.x, pos.y);
                pieceComponent.setUnavailable();
                if (currentPlayer == 1)
                {
                    int position = pieceComponent.getIndex();
                    Support1.Instance.SetPositionFree(position);
                    if(Support1.Instance.isSupportCleared() && !TurnSystem.getFirstSupport())
                    {
                        TurnSystem.setFirstSupport();
                    }    
                }
                else if (currentPlayer == 2)
                {
                    int position = pieceComponent.getIndex();
                    Support2.Instance.SetPositionFree(position);
                    if (Support2.Instance.isSupportCleared() && !TurnSystem.getFirstSupport())
                    {
                        TurnSystem.setFirstSupport();
                    }
                }
                else if (currentPlayer == 3)
                {
                    int position = pieceComponent.getIndex();
                    Support3.Instance.SetPositionFree(position);
                    if (Support3.Instance.isSupportCleared() && !TurnSystem.getFirstSupport())
                    {
                        TurnSystem.setFirstSupport();
                    }
                }
                else if (currentPlayer == 4)
                {
                    int position = pieceComponent.getIndex();
                    Support4.Instance.SetPositionFree(position);
                    if (Support4.Instance.isSupportCleared() && !TurnSystem.getFirstSupport())
                    {
                        TurnSystem.setFirstSupport();
                    }
                }
                int tempI, tempJ;
                if (pos.x < 10) { tempI = 10 + 10 - pos.x; }
                else { tempI = pos.x; }
                if (pos.y < 24) { tempJ = 24 + 24 - pos.y; }
                else { tempJ = pos.y; }
                if (tempI > maxI)
                {
                    maxI = tempI;
                    if (maxI > 14)
                    {
                        IMoveCamera cameraMover = FindObjectOfType<CustomCamera>() as IMoveCamera;
                        if (cameraMover != null)
                        {
                            cameraMover.increaseRange();
                        }
                    }
                }
                if (tempJ > maxJ)
                {
                    maxJ = tempJ;
                    if (maxJ > 33)
                    {
                        IMoveCamera cameraMover = FindObjectOfType<CustomCamera>() as IMoveCamera;
                        if (cameraMover != null)
                        {
                            cameraMover.increaseRange();
                        }
                    }
                }
            }
            else
            {
                Debug.LogWarning("Invalid currentIndex value!");
            }

            currentObject = null;
            potentialPositions.Clear();
            currentIndex = -1;
            TurnSystem.endFindingPostion();
        }
    }


    private void CancelTeleport(GameObject obj)
    {
        currentObject.transform.position = originalPosition;
        currentObject.transform.rotation = originalRotation;
        IPieceObject pieceComponent = obj.GetComponent<IPieceObject>();
        pieceComponent.setMaterial();
        currentObject = null;
        potentialPositions.Clear();
        currentIndex = -1;
        TurnSystem.endFindingPostion();
    }

    private void CheckRectangleFormed(int row, int column)
    {
        for (int i = row - 1; i <= row; i++)
        {
            for (int j = column - 2; j <= column; j++)
            {
                if (i >= 0 && i < rows - 1 && j >= 0 && j < columns - 2 && (i + (j + 1)) % 2 == 1 &&
                    matrix[i, j].occupied && matrix[i + 1, j].occupied && matrix[i, j + 1].occupied &&
                    matrix[i + 1, j + 1].occupied && matrix[i, j + 2].occupied && matrix[i + 1, j + 2].occupied)
                {
                    TurnSystem.incrementScore(TurnSystem.GetCurrentTurn(), 60);
                }
            }
        }
    }

    private Quaternion GetRotationByPhase(int phase)
    {
        switch (phase)
        {
            case 1: return phase1;
            case 2: return phase2;
            case 3: return phase3;
            case 4: return phase4;
            case 5: return phase5;
            case 6: return phase6;
            default: Debug.Log("Error!"); return Quaternion.identity;
        }
    }
}