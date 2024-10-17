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

    void ScoreSet(float CurrentScore, string CurrentName) // 이름 입력받는부분이 구현되면 맞춰서 수정
    {
        PlayerPrefs.SetString("CurrentPlayerName", CurrentName);
        PlayerPrefs.SetFloat("CurrentPlayerScore", CurrentScore);

        float tmpscore = 0f;
        string tmpname = string.Empty;

        for (int i = 0; i < 7; i++)
        {
            //저장된 최고점수와 이름 가져오기 
            BestScore[i] = PlayerPrefs.GetFloat(i + "BestScore");
            BestName[i] = PlayerPrefs.GetString(i + "BestName");

            //현재 점수가 랭킹에 오를 수 있을 때
            while (BestScore[i] < CurrentScore)
            {
                //자리바꾸기
                tmpscore = BestScore[i];
                tmpname = BestName[i];
                BestScore[i] = CurrentScore;
                BestName[i] = CurrentName;

                //랭킹에 저장
                PlayerPrefs.SetFloat(i + "BestScore", CurrentScore);
                PlayerPrefs.SetString(i.ToString() + "BestName", CurrentName);

                //다음 반복을 위한 준비
                CurrentScore = tmpscore;
                CurrentName = tmpname;
            }
        }
        //랭킹에 맞춰 이름 점수 저장
        for (int i = 0; i < 7; i++)
        {
            PlayerPrefs.SetFloat(i + "BestScore", BestScore[i]);
            PlayerPrefs.SetString(i.ToString() + "BestName", BestName[i]);
        }

        PlayerPrefs.Save();

    }

    //플레이어의 이름 , 점수 텍스트를 현재 '나'의 이름과 점수에 표시
    //RankNameCurrent.text = PlayerPrefs.GetString("CurrentPlayerName");
    //RankScoreCurrent.text = string.foamat("{0}점" , PlayerPrefs.GetFloat("CurrentPlayerScore"));

    //랭킹에 맞춰 불러온 점수와 이름 표시
    //for (int i = 0; i< 5; i++)
    //{
    //    RankScore[i] = PlayerPrefs.GetFloat(int + "BestScore");
    //    RankScoreText[i].text = string.Format("{0}점" , RankScore[i]);
    //    RankName[i] = PlayerPrefs.Getstring(i.ToString() + "BestName");
    //    RankNameText[i].text = string.Format(RankName[i]);

    // 자신이 랭킹안에 들었다면 강조
    //    If (RankScoreCurrent.text == RankScoreText[i].text)
    //    {
    //        Color Rank = new Color(255, 255, 0);
    //        RankText[i].color = Rank;
    //        RankNameText[i].color = Rank;
    //        RankScoreText[i].color = Rank;
    //    }
    //}


    // RankNameCurrent = 현재 나의 이름을 보여주는 텍스트 
    // RankScoreCurrent = 현재 나의 점수를 보여주는 텍스트
    // ui 부분이 완성되면 그에 맞게 수정 , 점수 표시를 ~점 ~m로 할것인지 
}
