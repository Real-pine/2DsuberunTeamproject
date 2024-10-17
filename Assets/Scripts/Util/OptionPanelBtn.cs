using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPanelBtn : MonoBehaviour
{
    public GameObject optionPanel;[SerializeField]
    


    void Update()
    {
        // ESC Ű�� ������ OpenOptionPanel() �޼��� ȣ��
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
            Time.timeScale = 0; // ���� �Ͻ� ����
        }

        else
        {
            Time.timeScale = 1;
        }
    }
}
