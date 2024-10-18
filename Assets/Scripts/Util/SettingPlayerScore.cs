using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //TODO : 플레이어 구분은 Character클래스의 playerNumber로 구별할 수 있음
    //      playerNumber1은 1P, playerNumber2는 2P임.
    //      스코어는 PlayGameScene이 시작하고 각 캐릭터의 hp==0이 될때까지시간
    //      여기서 각 플레이어의 스코어 데이터를 게임매니저에 넘겨주고
    //      게임매니저에 저장된 스코어를 RankingSet을 통해 랭크저장
public class SettingPlayerScore : MonoBehaviour
{
    private float player1StartTime;
    private float player2StartTime;
    private int _playerNumber;
    private bool isScoring = true;

    private void Start()
    {
        int _playerNumber = GetComponent<Character>().playerNumber;
        

        player1StartTime = Time.time;
        if (!GameManager.Instance.isSolo)
        {
            player2StartTime = Time.time;
        }
        
    }
    private void Update()
    {
        if(isScoring)
        {
            SetPlayerScore(_playerNumber);
        }   
    }

    public void StopScoring()
    {
        isScoring = false;
    }

    public void SetPlayerScore(int playerNumber)
    {
        float score = Time.time - (playerNumber == 1 ? player1StartTime : player2StartTime);
        if (playerNumber == 1)
        {
            GameManager.Instance.SetPlayer1Score(score);
        }
        else
        {
            GameManager.Instance.SetPlayer1Score(score);
            GameManager.Instance.SetPlayer2Score(score);
        }
    }
        
}
