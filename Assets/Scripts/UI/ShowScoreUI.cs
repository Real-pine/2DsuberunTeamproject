using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text player1Score;
    [SerializeField] private TMP_Text player2Score;

    private void Update()
    {
        ShowScore();
    }

    private void ShowScore()
    {
        if(GameManager.Instance.isSolo)
        {
            player1Score.text = $"{GameManager.Instance.player1Score:F2}M";
            player2Score.text = $"Input Coin";
        }
        else
        {
            player1Score.text = $"{GameManager.Instance.player1Score:F2}M";
            player2Score.text = $"{GameManager.Instance.player2Score:F2}M";
        }
    }
}
