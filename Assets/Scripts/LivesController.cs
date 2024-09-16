using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesController : MonoBehaviour
{
    private TextMeshProUGUI livesText;
    private int playerLives = 3;

    private void Awake()
    {
        livesText = GetComponent<TextMeshProUGUI>();
    }

    public void DecreaseLives(int decrement)
    {
        playerLives -= decrement;
        RefreshUI();
    }

    public int getlives()
    {
        return playerLives;
    }

    private void RefreshUI()
    {
        livesText.text = "Player Lives: " + playerLives;
    }
}
