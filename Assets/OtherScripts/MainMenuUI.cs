using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button singlePlayerButton;
    [SerializeField] private GameObject playerSelectionPanel;
    [SerializeField] private GameObject playerSinglePanel;
    public string nextSceneName;

    void Start()
    {
        playerSelectionPanel.SetActive(false);
        playerSinglePanel.SetActive(false);
    }

    public void OnPlayButtonPressed()
    {
        playerSinglePanel.SetActive(false);
        playerSelectionPanel.SetActive(true);
    }

    private void Awake()
    {
        playButton.onClick.AddListener(OnPlayButtonPressed);
        quitButton.onClick.AddListener(QuitGame);
        singlePlayerButton.onClick.AddListener(singlePlayer);
    }

    private void singlePlayer()
    {
        playerSelectionPanel.SetActive(false);
        playerSinglePanel.SetActive(true);
    }

    private void QuitGame()
    {
#if UNITY_EDITOR        
#else
        Application.Quit();
#endif
    }
}
