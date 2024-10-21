using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectStagePanel : MonoBehaviour
{
    [SerializeField] private Button easyButton;
    [SerializeField] private Button normalButton;
    [SerializeField] private Button hardButton;


    private void Start()
    {
        //버튼에 리스너 등록
        easyButton.onClick.AddListener(() => SelectDifficulty(1));
        normalButton.onClick.AddListener(() => SelectDifficulty(2));
        hardButton.onClick.AddListener(() => SelectDifficulty(3));
    }

    // TODO: Easy버튼을 누르면 int값 1을 GameManager에 저장,
    //      Normal이면 2를 저장,
    //      Hard라면 3을 저장
    private void SelectDifficulty(int difficulty)
    {
        GameManager.Instance.SetDifficulty(difficulty);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.DM28);
        SceneManager.LoadScene("PlayGameScene");
    }
}
