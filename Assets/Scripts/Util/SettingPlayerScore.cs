using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //TODO : �÷��̾� ������ CharacterŬ������ playerNumber�� ������ �� ����
    //      playerNumber1�� 1P, playerNumber2�� 2P��.
    //      ���ھ�� PlayGameScene�� �����ϰ� �� ĳ������ hp==0�� �ɶ������ð�
    //      ���⼭ �� �÷��̾��� ���ھ� �����͸� ���ӸŴ����� �Ѱ��ְ�
    //      ���ӸŴ����� ����� ���ھ RankingSet�� ���� ��ũ����
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
