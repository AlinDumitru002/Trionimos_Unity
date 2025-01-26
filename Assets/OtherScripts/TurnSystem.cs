using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Linq;

public class TurnSystem : MonoBehaviour
{
    public static event Action<int> OnTurnChanged;
    private static int currentTurn = 1;
    private static int picking = 1;
    private static int pieces_picked = 0;
    private static int[] score = new int[5];
    private static int[] chances = new int[5];
    private static int pass = 0;
    private static bool passPressedThisTurn = false;
    private static bool endCurrentGame = false;
    private static bool isMatrixEmpty = true;
    private static bool isTableCleared = true;
    private static bool[] supportsCleared = new bool[5];
    private static bool firstSupportCleared = false;
    private static int numberPlayers = 3;
    private static bool singlePlayer = false;
    private static bool passAprovved = false;
    private static int bots = 4;
    private static int reals = 0;

    void Start()
    {
        for (int i = 0; i < 5; i++)
            supportsCleared[i] = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            HandlePassPress();
        }
    }

    public static bool getFirstSupport()
    {
        return firstSupportCleared;
    }

    public static void setFirstSupport()
    {
        firstSupportCleared = true;
        incrementScore(currentTurn, 30);
    }

    public static int getBots()
    {
        return bots;
    }

    public static int getReals()
    {
        return reals;
    }

    public static void setBots(int number)
    {
        bots = number;
    }

    public static void setReals(int number)
    {
        reals = number;
    }

    public static bool getSinglePlayer()
    {
        return singlePlayer;
    }

    public static void setSinglePlayer()
    {
        singlePlayer = true;
    }

    public static string getMessage()
    {
        if (picking == 1)
            return "Instrucțiuni - I\nVizualizarea suportului - Cifra jucătorului\nRândul jucătorului " + currentTurn + " să aleagă o piesă.";
        else if (picking == 2)
            return "Instrucțiuni - I\nValoarea maximă a avut-o jucătorul " + currentTurn + "\nAlege o piesă să fie prima pusă jos.";
        else if (picking == 3)
            return "Instrucțiuni - I\nVizualizare piese intoarse - A\nCerere pas - P\nRotire piesa pe suport - R\nRândul jucătorului " + currentTurn + " de a pune o piesă pe masă,";
        else return "Instrucțiuni - I\nJucătorul " + currentTurn + " a ales o piesă căreia s-au găsit locuri potrivite\nParcurgere locuri înainte - ->\nParcurgere locuri înapoi - <-\nConfirmare loc - Enter\nAnulare căutare loc - Backspace";
    }

    public static void setNumberPlayers(int number)
    {
        numberPlayers = number;
    }

    public static int getNumberPlayers()
    {
        return numberPlayers;
    }

    private static bool allSupportsCleared()
    {
        foreach (bool support in supportsCleared)
        {
            if (!support)
            {
                return false;
            }
        }
        return true;
    }

    public static bool getSituation()
    {
        return endCurrentGame;
    }

    public static void setMatrix()
    {
        isMatrixEmpty = true;
    }

    public static bool getMatrix()
    {
        return isMatrixEmpty;
    }

    public static void setSupport(int player)
    {
        supportsCleared[player] = true;
    }

    public static bool getSupport(int player)
    {
        return supportsCleared[player];
    }

    public static void setTable()
    {
        isTableCleared = true;
    }

    public static bool getTable()
    {
        return isTableCleared;
    }

    public static void HandlePassPress()
    {
        if ((picking == 3 && !passPressedThisTurn) && (pieces_picked ==56 ||
                    (currentTurn == 1 && Support1.Instance.isSupportCleared()) ||
                    (currentTurn == 2 && Support2.Instance.isSupportCleared()) ||
                    (currentTurn == 3 && Support3.Instance.isSupportCleared()) ||
                    (currentTurn == 4 && Support4.Instance.isSupportCleared())))
        {
            pass++;
            passPressedThisTurn = true;
            passAprovved = true;
            NextTurn2();
            if (pass >= numberPlayers || (getNumberPlayers() == 2 & pass >= 2))
            {
                bool tempSingle = singlePlayer;
                int tempBots = bots;
                int tempReals = reals;
                int sceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(sceneIndex);
                currentTurn = 1;
                picking = 1;
                pieces_picked = 0;
                pass = 0;
                firstSupportCleared = false;
                IPieceObject[] pieceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IPieceObject>().ToArray();
                foreach (IPieceObject piece in pieceObjects)
                {
                    if (piece.getAvailable())
                    {
                        int tempIndex = piece.getSupport();
                        if (tempIndex == -1)
                            tempIndex = 0;
                        int value = piece.getMax();
                        decrementScore(tempIndex, value);
                    }
                }
                    for (int i = 0; i < 5; i++)
                {
                    chances[i] = 0;
                }
                if (tempSingle)
                {
                    setSinglePlayer();
                    setReals(tempReals);
                    setBots(tempBots);
                    pauseUpdate = false;
                }
            }
            else
                passAprovved = false;
        }
    }

    public static int getScore(int player)
    {
        return score[player];
    }

    public static void incrementScore(int player, int val)
    {
        score[player] += val;
    }

    public static void decrementScore(int player, int val)
    {
        score[player] = score[player] - val;
    }

    public static int getChances(int player)
    {
        return chances[player];
    }

    public static void incrementChances(int player)
    {
        chances[player]++;
        pieces_picked++;
    }

    public static void set0Chances(int player)
    {
        chances[player] = 0;
        NextTurn2();
    }

    public static int GetCurrentTurn()
    {
        return currentTurn;
    }

    public static int pickingGamePhase()
    {
        return picking;
    }

    public static void incrementPiecesPicked()
    {
        pieces_picked++;
    }

    public static void changePickingPhase()
    {
        if (picking == 1)
            picking = 2;
        else
            picking = 3;
    }

    public static void startFindingPosition()
    {
        picking = 4;
    }

    public static void endFindingPostion()
    {
        picking = 3;
    }

    public static bool getPassAprovved()
    {
        return passAprovved;
    }

    public static int maxSupports()
    {
        int tempMax, tempNum;
        if (Support1.getMaxim() >= Support2.getMaxim())
        {
            tempMax = Support1.getMaxim();
            tempNum = 1;
        }
        else
        {
            tempMax = Support2.getMaxim();
            tempNum = 2;
        }
        if (tempMax < Support3.getMaxim())
        {
            tempMax = Support3.getMaxim();
            tempNum = 3;
        }
        if (tempMax < Support4.getMaxim())
        {
            tempMax = Support4.getMaxim();
            tempNum = 4;
        }
        return tempNum;
    }

    public static void NextTurn()
    {
        if (numberPlayers == 2)
        {
            if (currentTurn == 1)
            {
                currentTurn = 3;
                OnTurnChanged?.Invoke(currentTurn);
                incrementPiecesPicked();
            }
            else
            {
                currentTurn = 1;
                OnTurnChanged?.Invoke(currentTurn);
                incrementPiecesPicked();
            }
        }
        else if (numberPlayers == 3)
        {
            if (currentTurn < 3)
            {
                currentTurn++;
                OnTurnChanged?.Invoke(currentTurn);
                incrementPiecesPicked();
            }
            else
            {
                currentTurn = 1;
                OnTurnChanged?.Invoke(currentTurn);
                incrementPiecesPicked();
            }
        }
        else if (numberPlayers == 4)
        {
            if (currentTurn < 4)
            {
                currentTurn++;
                OnTurnChanged?.Invoke(currentTurn);
                incrementPiecesPicked();
            }
            else
            {
                currentTurn = 1;
                OnTurnChanged?.Invoke(currentTurn);
                incrementPiecesPicked();
            }
        }
        if (pieces_picked == numberPlayers * 9)
        {
            changePickingPhase();
            IMoveCamera cameraMover = FindObjectOfType<CustomCamera>() as IMoveCamera;
            if (cameraMover != null)
            {
                int temp = maxSupports();
                currentTurn = temp;
                if (temp == 1)
                    cameraMover.PositionSupport1();
                else if (temp == 2)
                    cameraMover.PositionSupport2();
                else if (temp == 3)
                    cameraMover.PositionSupport3();
                else
                    cameraMover.PositionSupport4();
            }
        }


        if (!passPressedThisTurn)
        {
            pass = 0;
        }

        passPressedThisTurn = false;
    }

    public static void NextTurn2()
    {

        if (numberPlayers == 2)
        {
            chances[currentTurn] = 0;
            if (currentTurn == 1)
            {
                currentTurn = 3;
                OnTurnChanged?.Invoke(currentTurn);
            }
            else
            {
                currentTurn = 1;
                OnTurnChanged?.Invoke(currentTurn);
            }
        }
        else if (numberPlayers == 3)
        {
            chances[currentTurn] = 0;
            if (currentTurn < 3)
            {
                currentTurn++;
                OnTurnChanged?.Invoke(currentTurn);
            }
            else
            {
                currentTurn = 1;
                OnTurnChanged?.Invoke(currentTurn);
            }
        }
        else if (numberPlayers == 4)
        {
            chances[currentTurn] = 0;
            if (currentTurn < 4)
            {
                currentTurn++;
                OnTurnChanged?.Invoke(currentTurn);
            }
            else
            {
                currentTurn = 1;
                OnTurnChanged?.Invoke(currentTurn);
            }
        }


        if (!passPressedThisTurn)
        {
            pass = 0;
        }

        passAprovved = false;
        passPressedThisTurn = false;

        IMoveCamera cameraMover = FindObjectOfType<CustomCamera>() as IMoveCamera;
        if (cameraMover != null)
        {
            if (currentTurn == 1)
                cameraMover.PositionSupport1();
            else if (currentTurn == 2)
                cameraMover.PositionSupport2();
            else if (currentTurn == 3)
                cameraMover.PositionSupport3();
            else
                cameraMover.PositionSupport4();
        }
        if (currentTurn > getReals() && singlePlayer)
        {
            TurnSystem instance = FindObjectOfType<TurnSystem>();
            if (instance != null)
            {
                instance.StartCoroutine(instance.PauseUpdateForSeconds(3f));
            }
            else
            {
                Debug.LogWarning("Nu am găsit o instanță a TurnSystem în scenă pentru a apela corutina.");
            }
        }
        IPieceObject[] pieceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IPieceObject>().ToArray();

        foreach (IPieceObject piece in pieceObjects)
        {
            piece.resetK();
        }
    }
    public static bool pauseUpdate = false;
    public static bool getPause()
    {
        return pauseUpdate;
    }

    public static void setPause()
    {
        if (!pauseUpdate)
            pauseUpdate = true;
        else
            pauseUpdate = false;
    }

    public IEnumerator PauseUpdateForSeconds(float seconds)
    {
        pauseUpdate = true;

        yield return new WaitForSeconds(seconds);

        pauseUpdate = false;
    }
}

