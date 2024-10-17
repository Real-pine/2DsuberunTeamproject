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

        Player1PButton.onClick.AddListener(() => SetPlayerMode(true));
        Player2PButton.onClick.AddListener(() => SetPlayerMode(false));
    }

    // TODO : �÷��̾� ���� �����������ϴ� �޼��带 �ۼ��ؾ��� ��
    private void SetPlayerMode(bool _isSolo)
    {
        GameManager.Instance.SetSolo(_isSolo);
        //���� �гη� ��ȯ
        uiManager.OpenPanel(PanelType.InputPlayerName);
    }
}
