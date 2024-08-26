using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesController : MonoBehaviour
{
    private TextMeshProUGUI lives_text;
    private int player_lives = 3;

    private void Awake()
    {
        lives_text = GetComponent<TextMeshProUGUI>();
    }

    public void DecreaseLives(int decrement)
    {
        player_lives -= decrement;
        RefreshUI();
    }

    public int getlives()
    {
        return player_lives;
    }

    private void RefreshUI()
    {
        lives_text.text = "Player Lives: " + player_lives;
    }
}
