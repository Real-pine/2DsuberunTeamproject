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
        // 현재 패널의 활성 상태를 반전
        bool isActive = optionPanel.activeSelf;
        optionPanel.SetActive(!isActive); // 패널 열기/닫기

        // 패널이 활성화되면 게임 일시 정지, 그렇지 않으면 재개
        Time.timeScale = isActive ? 1 : 0; // isActive가 true면 1, false면 0
    }
}
