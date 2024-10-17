using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isSolo;

    //StartScene ���� ���� �÷��̾� �̸�
    private string player1Name;
    private string player2Name;

    //StartScene ���� ������ ĳ����
    public int player1Character { get; }
    public int player2Character { get; }

    //StartScene ���� ������ ���̵�
    private int stageDifficulty;

    //MainScene ���� ����Ǵ� ����
    private float player1Score;
    private float player2Score;

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
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
