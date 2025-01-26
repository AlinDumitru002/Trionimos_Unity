using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class selectSinglePlayer : MonoBehaviour
{
    public TMP_InputField humanElement; 
    public TMP_InputField botsElement;
    public Button confirm;
    public TMP_Text errors;
    public int maxPlayers = 4;
    public string nextSceneName;

    void Start()
    {
        confirm.onClick.AddListener(OnConfirm);
    }

    void OnConfirm()
    {
        int humanPlayers = 0;
        int botPlayers = 0;

        if (int.TryParse(humanElement.text, out humanPlayers) && int.TryParse(botsElement.text, out botPlayers))
        {
            if (humanPlayers + botPlayers <= maxPlayers && humanPlayers + botPlayers > 1)
            {
                SceneManager.LoadScene(nextSceneName);
                TurnSystem.setSinglePlayer();
                TurnSystem.setNumberPlayers(humanPlayers + botPlayers);
                TurnSystem.setReals(humanPlayers);
                TurnSystem.setBots(botPlayers);
            }
            else
            {
                errors.text = "Numărul total de jucători nu poate depăși " + maxPlayers.ToString();
            }
        }
        else
        {
            errors.text = "Introdu numere valide pentru jucători și boți.";
        }
    }
}
