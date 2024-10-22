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
        // ���� �г��� Ȱ�� ���¸� ����
        bool isActive = optionPanel.activeSelf;
        optionPanel.SetActive(!isActive); // �г� ����/�ݱ�

        // �г��� Ȱ��ȭ�Ǹ� ���� �Ͻ� ����, �׷��� ������ �簳
        Time.timeScale = isActive ? 1 : 0; // isActive�� true�� 1, false�� 0
    }
}
