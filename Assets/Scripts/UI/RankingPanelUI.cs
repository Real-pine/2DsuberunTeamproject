using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class RankingPanelUI : MonoBehaviour
{
    [SerializeField] private TMP_Text[] scoreText;
    [SerializeField] private TMP_Text[] nameText;

    // TODO : ����� �̸��� �ְ��������� RankingBoxPanel�� Text�� �� ����
    //      ��� ������������ �����ؾ��ϰ�, ���ο� �ְ� ������ �����ϸ� 
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
