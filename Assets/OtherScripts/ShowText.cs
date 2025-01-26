using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    private int numberPlayers;
    private string textValue;
    private string textValueInfo1;
    private string textValueInfo2;
    public Text textElement;
    public Text textElementInfo;

    void Start()
    {
        numberPlayers = TurnSystem.getNumberPlayers();
        if (numberPlayers == 2)
        {
            textValue = "Player1: 0     Player2: 0";
            textElement.text = textValue;
        }
        else if (numberPlayers == 3)
        {
            textValue = "Player1:  0" +
                "     Player2:  0" +
                "     Player3:  0";
            textElement.text = textValue;
        }
        else if (numberPlayers == 4)
        {
            textValue = "Player1:  0" +
                "     Player2:  0" +
                "     Player3:  0" +
                "     Player4:  0";
            textElement.text = textValue;
        }
        textValueInfo1 = "Instrucíuni - I";
        textValueInfo2 = "Ceva\nnou";
        textElementInfo.text = textValueInfo1;
    }

    void Update()
    {
        textValueInfo2 = TurnSystem.getMessage();
        if (numberPlayers == 2)
        {
            textValue = "Player1: " + TurnSystem.getScore(1) +
                "     Player2: " + TurnSystem.getScore(3);
            textElement.text = textValue;
        }
        else if (numberPlayers == 3)
        {
            textValue = "Player1: " + TurnSystem.getScore(1) +
                "     Player2: " + TurnSystem.getScore(2) +
                "     Player3: " + TurnSystem.getScore(3);
            textElement.text = textValue;
        }
        else if (numberPlayers == 4)
        {
            textValue = "Player1: " + TurnSystem.getScore(1) +
                "     Player2: " + TurnSystem.getScore(2) +
                "     Player3: " + TurnSystem.getScore(3) +
                "     Player4: " + TurnSystem.getScore(4);
            textElement.text = textValue;
        }
        for (int i = 0; i < 5; i++)
            if (TurnSystem.getScore(i) >= 400)
            {
                if (TurnSystem.getNumberPlayers() == 2 && i == 3)
                    textValue = "Player 2 won!";
                else
                    textValue = "Player " + i + " won!";
                textElement.text = textValue;
            }
        if (textElementInfo.text != textValueInfo1)
            textElementInfo.text = textValueInfo2;

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (textElementInfo.text == textValueInfo1)
            {
                textElementInfo.text = textValueInfo2;
            }
            else
                textElementInfo.text = textValueInfo1;
        }
    }
}
