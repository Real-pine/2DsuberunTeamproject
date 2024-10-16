using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ranking : MonoBehaviour
{
    public Text scoreText, myrank;
    public Text[] rank = new Text[5];
    public int score = 0;
    private int[] bestScore = new int[5];
    private string[] bestName = new string[5];
    void ScoreSet(int currentScore, string currentName)
    {
        PlayerPrefs.SetString("CurrentPlayerName", currentName);
        PlayerPrefs.SetInt("CurrentPlayerScore", currentScore);

        int tmpScore = 0;
        string tmpName = "";

        for (int i = 0; i < 5; i++)
        {
            bestScore[i] = PlayerPrefs.GetInt(i + "BestScore");
            bestName[i] = PlayerPrefs.GetString(i + "BestName");

            while (bestScore[i] < currentScore)
            {
                tmpScore = bestScore[i];
                tmpName = bestName[i];
                bestScore[i] = currentScore;
                bestName[i] = currentName;

                //��ŷ ����
                PlayerPrefs.SetInt(i + "BestScore", currentScore);
                PlayerPrefs.SetString(i + "BestName", currentName);
                currentScore = tmpScore;
                currentName = tmpName;
            }
        }
        //��ŷ ���
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt(i + "BestScore", bestScore[i]);
            PlayerPrefs.SetString(i + "BestName", bestName[i]);
            Debug.Log("[��ŷ] " + PlayerPrefs.GetString(i + "BestName") + PlayerPrefs.GetInt(i + "BestScore"));
            rank[i].text = bestName[i] + " " + bestScore[i].ToString();
        }
    }

    void ScoreSet1(int currentScore, string currentName)
    {
        //Debug.Log("currentName: " + currentName);
        //�ϴ� ���翡 �����ϰ� ����
        PlayerPrefs.SetString("CurrentPlayerName", currentName);
        PlayerPrefs.SetInt("CurrentPlayerScore", currentScore);
        //Debug.Log("���"+ PlayerPrefs.GetInt("CurrentPlayerScore").ToString());

        int tmpScore = 0;
        string tmpName = "";

        for (int i = 0; i < 5; i++)
        {
            //����� �ְ������� �̸��� ��������
            bestScore[i] = PlayerPrefs.GetInt(i + "BestScore");
            bestName[i] = PlayerPrefs.GetString(i + "BestName");
            //Debug.Log("[��ŷ���] �̸�: " + bestName[i]+ "����: " + bestScore[i]);

            //���� ������ ��ŷ�� ���� �� ���� ��
            while (bestScore[i] < currentScore)
            {
                //�ڸ��ٲٱ�!
                tmpScore = bestScore[i];
                tmpName = bestName[i];
                bestScore[i] = currentScore;
                bestName[i] = currentName;

                //��ŷ�� ����
                PlayerPrefs.SetInt(i + "BestScore", currentScore);
                //PlayerPrefs.SetString(i.ToString() + "BestName", currentName);
                PlayerPrefs.SetString(i + "BestName", currentName);

                //���� �ݺ��� ���� �غ�
                currentScore = tmpScore;
                currentName = tmpName;
            }
        }
        //��ŷ�� ���� ������ �̸� ����� ���
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt(i + "BestScore", bestScore[i]);
            PlayerPrefs.SetString(i + "BestName", bestName[i]);
            //PlayerPrefs.SetString(i.ToString() + "BestName", bestName[i]);
            Debug.Log("[��ŷ] " + PlayerPrefs.GetString(i + "BestName") + PlayerPrefs.GetInt(i + "BestScore"));
            rank[i].text = bestName[i] + " " + bestScore[i].ToString();
        }
    }
}
