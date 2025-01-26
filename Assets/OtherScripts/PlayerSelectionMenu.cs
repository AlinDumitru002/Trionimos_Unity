using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSelectionMenu : MonoBehaviour
{
    public Button button2Players;
    public Button button3Players;
    public Button button4Players;
    public string nextSceneName;

    void Start()
    {
        button2Players.onClick.AddListener(() => OnPlayerSelected(2));
        button3Players.onClick.AddListener(() => OnPlayerSelected(3));
        button4Players.onClick.AddListener(() => OnPlayerSelected(4));
    }

    void OnPlayerSelected(int number)
    {
        TurnSystem.setNumberPlayers(number);
        SceneManager.LoadScene(nextSceneName);
    }
}
