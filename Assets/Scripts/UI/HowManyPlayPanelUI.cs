using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowManyPlayPanel : MonoBehaviour
{
    private UIManager uiManager;

    [SerializeField] private Button Player1PButton;
    [SerializeField] private Button Player2PButton;

    private void Start()
    {
        uiManager = GetComponent<UIManager>();

        Player1PButton.onClick.AddListener(OnClickToInputPlayerName);
        Player2PButton.onClick.AddListener(OnClickToInputPlayerName);
        // TODO : �����ʷ� 1P���� 2P���� �Ǵ��ϴ� �̺�Ʈ ����
        // TODO : �÷��̾� �� �����͸� �Ѱ��ִ� �̺�Ʈ ����
    }

    private void OnClickToInputPlayerName()
    {
        uiManager.OpenPanel(PanelType.InputPlayerName);
    }

    // TODO : 1P���� 2P���� �Ǵ��ϴ� �Լ�(OnClickToInputPlayerName()�޼��忡 �����ص� �ɵ�?)

    // TODO : �÷��̾� ���� ĳ���� �����Ϳ� �Ѱ�����ϴ� �޼��带 �ۼ��ؾ��� ��
}
