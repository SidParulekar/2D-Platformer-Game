using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreController : MonoBehaviour
{
   private TextMeshProUGUI score_text;

   private int score = 0;

    private void Awake()
    {
        score_text = GetComponent<TextMeshProUGUI>();    
    }

    public void IncreaseScore(int increment)
    {
        score += increment;
        RefreshUI();
    }

    private void RefreshUI()
    {
        score_text.text = "Score: " + score;
    }
}
