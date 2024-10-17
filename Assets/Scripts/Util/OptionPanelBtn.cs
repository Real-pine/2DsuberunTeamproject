using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPanelBtn : MonoBehaviour
{
    public GameObject optionPanel;[SerializeField]
    


    void Update()
    {
        // ESC 키가 눌리면 OpenOptionPanel() 메서드 호출
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenOptionPanel();
        }
    }

    public void OpenOptionPanel()
    {
        optionPanel.SetActive(!optionPanel.activeSelf);

        if (optionPanel.activeSelf)
        {
            Time.timeScale = 0; // 게임 일시 정지
        }

        else
        {
            Time.timeScale = 1;
        }
    }
}
