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
    private Character character;
    private float playerStartTime;
    private int _playerNumber;
    private bool isScoring = true;

    private void Start()
    {
        character = GetComponent<Character>();
        InitializePlayerScore(character.playerNumber);
        playerStartTime = Time.time;
    }
    private void Update()
    {
        if(isScoring)
        {
            SetPlayerScore(character.playerNumber);
        }   
    }

    public void StopScoring()
    {
        isScoring = false;
    }

    public void SetPlayerScore(int playerNumber)
    {
        float score = Time.time - playerStartTime;
        if (playerNumber == 1)
        {
            GameManager.Instance.SetPlayer1Score(score);
        }
        else if (playerNumber == 2) 
        {
            GameManager.Instance.SetPlayer2Score(score);
        }
    }

    public void InitializePlayerScore(int playerNumber)
    {
        if ( playerNumber == 1)
        {
            GameManager.Instance.SetPlayer1Score(0);
        }
        else if (playerNumber == 2)
        {
            GameManager.Instance.SetPlayer2Score(0);
        }
    }
        
}
