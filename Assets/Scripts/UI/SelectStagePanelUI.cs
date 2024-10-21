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
        //��ư�� ������ ���
        easyButton.onClick.AddListener(() => SelectDifficulty(1));
        normalButton.onClick.AddListener(() => SelectDifficulty(2));
        hardButton.onClick.AddListener(() => SelectDifficulty(3));
    }

    // TODO: Easy��ư�� ������ int�� 1�� GameManager�� ����,
    //      Normal�̸� 2�� ����,
    //      Hard��� 3�� ����
    private void SelectDifficulty(int difficulty)
    {
        GameManager.Instance.SetDifficulty(difficulty);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.DM28);
        SceneManager.LoadScene("PlayGameScene");
    }
}
