using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WhenGameOver : MonoBehaviour
{
    public static WhenGameOver Instance { get; private set; }

    [SerializeField] private Button retryButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Image gameOverImage;
    [SerializeField] private TMP_Text player1Score;
    [SerializeField] private TMP_Text player2Score;
    
   
    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;

            gameOverImage.gameObject.SetActive(false);

            retryButton.onClick.AddListener(Retry);
            exitButton.onClick.AddListener(Exit);
        }
    }
    // TODO : Character�� hp<=0�� �Ǹ� ������ ���߰�, Time.timeScale=0.0f���Ǹ�
    //      ���ӿ����г��� �������Ѵ�. ��, 2P�÷��� �� �÷��̾� �Ѹ��� �׾ ������ ����ǰ�
    //      �� �÷��̾� ĳ���� ��� hp<=0�� �Ǿ���� ���ӿ��������� �۵��ȴ�.
    public void TriggerGameOverUI()
    {
        gameOverImage.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Retry()
    {
        Time.timeScale = 1.0f;
        SceneManager.GetActiveScene();
        SceneManager.LoadScene("PlayGameScene");
    }

    public void Exit()
    {
        Time.timeScale = 1.0f;
        SceneManager.GetActiveScene();
        SceneManager.LoadScene("StartScene");
    }

    public void PrintScoreText()
    {
        if (GameManager.Instance.isSolo)
        {
            player1Score.text = GameManager.Instance.player1Score.ToString("F2");
            player2Score = null;
        }
        else
        {
            player1Score.text = GameManager.Instance.player1Score.ToString("F2");
            player2Score.text = GameManager.Instance.player2Score.ToString("F2");
        }
    }
}
