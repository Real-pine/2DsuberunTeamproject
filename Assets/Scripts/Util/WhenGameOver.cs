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
    // TODO : Character의 hp<=0이 되면 게임이 멈추고, Time.timeScale=0.0f가되며
    //      게임오버패널이 열려야한다. 단, 2P플레이 시 플레이어 한명이 죽어도 게임은 진행되고
    //      두 플레이어 캐릭터 모두 hp<=0이 되어야지 게임오버로직이 작동된다.
    public void TriggerGameOverUI()
    {
        gameOverImage.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Retry()
    {
        Time.timeScale = 1.0f;
        GameManager.Instance.deadPlayerCount = 0;
        SceneManager.GetActiveScene();
        SceneManager.LoadScene("PlayGameScene");
        AudioManager.instance.PlayBgm(true);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.DM28);
    }

    public void Exit()
    {
        Time.timeScale = 1.0f;
        GameManager.Instance.deadPlayerCount = 0;
        SceneManager.GetActiveScene();
        SceneManager.LoadScene("StartScene");
        AudioManager.instance.PlaySfx(AudioManager.Sfx.DM28);
    }
}
