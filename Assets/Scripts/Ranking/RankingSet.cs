using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class RankingSet : MonoBehaviour
{
    private float[] BestScore = new float[7];
    private string[] BestName = new string[7];

    void ScoreSet(float CurrentScore, string CurrentName) // �̸� �Է¹޴ºκ��� �����Ǹ� ���缭 ����
    {
        PlayerPrefs.SetString("CurrentPlayerName", CurrentName);
        PlayerPrefs.SetFloat("CurrentPlayerScore", CurrentScore);

        float tmpscore = 0f;
        string tmpname = string.Empty;

        for (int i = 0; i < 7; i++)
        {
            //����� �ְ������� �̸� �������� 
            BestScore[i] = PlayerPrefs.GetFloat(i + "BestScore");
            BestName[i] = PlayerPrefs.GetString(i + "BestName");

            //���� ������ ��ŷ�� ���� �� ���� ��
            while (BestScore[i] < CurrentScore)
            {
                //�ڸ��ٲٱ�
                tmpscore = BestScore[i];
                tmpname = BestName[i];
                BestScore[i] = CurrentScore;
                BestName[i] = CurrentName;

                //��ŷ�� ����
                PlayerPrefs.SetFloat(i + "BestScore", CurrentScore);
                PlayerPrefs.SetString(i.ToString() + "BestName", CurrentName);

                //���� �ݺ��� ���� �غ�
                CurrentScore = tmpscore;
                CurrentName = tmpname;
            }
        }
        //��ŷ�� ���� �̸� ���� ����
        for (int i = 0; i < 7; i++)
        {
            PlayerPrefs.SetFloat(i + "BestScore", BestScore[i]);
            PlayerPrefs.SetString(i.ToString() + "BestName", BestName[i]);
        }

        PlayerPrefs.Save();

    }

    //�÷��̾��� �̸� , ���� �ؽ�Ʈ�� ���� '��'�� �̸��� ������ ǥ��
    //RankNameCurrent.text = PlayerPrefs.GetString("CurrentPlayerName");
    //RankScoreCurrent.text = string.foamat("{0}��" , PlayerPrefs.GetFloat("CurrentPlayerScore"));

    //��ŷ�� ���� �ҷ��� ������ �̸� ǥ��
    //for (int i = 0; i< 5; i++)
    //{
    //    RankScore[i] = PlayerPrefs.GetFloat(int + "BestScore");
    //    RankScoreText[i].text = string.Format("{0}��" , RankScore[i]);
    //    RankName[i] = PlayerPrefs.Getstring(i.ToString() + "BestName");
    //    RankNameText[i].text = string.Format(RankName[i]);

    // �ڽ��� ��ŷ�ȿ� ����ٸ� ����
    //    If (RankScoreCurrent.text == RankScoreText[i].text)
    //    {
    //        Color Rank = new Color(255, 255, 0);
    //        RankText[i].color = Rank;
    //        RankNameText[i].color = Rank;
    //        RankScoreText[i].color = Rank;
    //    }
    //}


    // RankNameCurrent = ���� ���� �̸��� �����ִ� �ؽ�Ʈ 
    // RankScoreCurrent = ���� ���� ������ �����ִ� �ؽ�Ʈ
    // ui �κ��� �ϼ��Ǹ� �׿� �°� ���� , ���� ǥ�ø� ~�� ~m�� �Ұ����� 
}
