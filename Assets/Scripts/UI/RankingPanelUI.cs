using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class RankingPanelUI : MonoBehaviour
{
    [SerializeField] private TMP_Text[] scoreText;
    [SerializeField] private TMP_Text[] nameText;

    // TODO : 저장된 이름과 최고점수들을 RankingBoxPanel에 Text로 쭉 나열
    //      대신 내림차순으로 나열해야하고, 새로운 최고 점수가 등장하면 
    private void Start()
    {
        UpdateRankingUI();
    }

    private void UpdateRankingUI()
    {
        for (int i = 0; i< 7; i++)
        {
            string bestName = PlayerPrefs.GetString(i + "BestName");
            float bestScore = PlayerPrefs.GetFloat(i + "BestScore");

            nameText[i].text = (i + 1) + ". " + bestName;
            scoreText[i].text = bestScore.ToString() + " M";
        }
    }
}
