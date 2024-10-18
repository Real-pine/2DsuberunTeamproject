using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public bool isSolo {get; private set;}
    //GameOver�Ǵ��� ���� ����
    private int deadPlayerCount = 0; 

    //StartScene ���� ���� �÷��̾� �̸�
    private string player1Name;
    private string player2Name;

    //StartScene ���� ������ ĳ����
    public int player1Character { get; private set; }
    public int player2Character { get; private set; }

    //StartScene ���� ������ ���̵�
    private int stageDifficulty;

    //MainScene ���� ����Ǵ� ����
    public float player1Score { get; private set; }
    public float player2Score { get; private set; }

    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void SetSolo(bool _isSolo)
    {
        isSolo = _isSolo;
    }

    public void SetName(string _player1Name, string _player2Name)
    {
        player1Name = _player1Name;
        player2Name = _player2Name;
    }

    public void SetDifficulty(int _difficulty)
    {
        stageDifficulty = _difficulty;
    }

    public void SetPlayer1Score(float score)
    {
        player1Score = score;
    }

    public void SetPlayer2Score(float score)
    {
        player2Score = score;
    }

    public void SetPlayerCharacter(int playerNumber, int characterType)
    {
        if(playerNumber == 1)
        {
            player1Character = characterType;
        }
        else if(playerNumber == 2)
        {
            player2Character = characterType;
        }
    }

    public string GetPlayer1Name()
    {  return player1Name; }

    // �÷��̾� ��� ���� ó��, ��� �÷��̾ ����ߴ��� Ȯ��
    public void OnPlayerDeath()
    {
        deadPlayerCount++;

        if (isSolo)
        {
            // �̱� �÷����� ��� ù ��° ������� �ٷ� ���� ����
            WhenGameOver.Instance.TriggerGameOverUI();
            RankingSet.Instance.ScoreSet(player1Score, player1Name);
        }
        else
        {
            int totalPlayer = 2;
            if (deadPlayerCount >= totalPlayer)
            {
                WhenGameOver.Instance.TriggerGameOverUI();
                RankingSet.Instance.ScoreSet(player1Score, player1Name);
                RankingSet.Instance.ScoreSet(player2Score, player2Name);
            }
        }

    }
}
