using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputPlayerNamePanelUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField player1InputField;
    [SerializeField] private TMP_InputField player2InputField;
    [SerializeField] private Button player1ConfirmButton;
    [SerializeField] private Button player2ConfirmButton;

    //���� �޼���
    [SerializeField] private GameObject errorMessage;
    [SerializeField] private TMP_Text errorMessageText;

    private UIManager uiManager;

    // �̸� ���ڼ� ����
    private int minNameLength = 2;
    private int maxNameLength = 5;

    private void Start()
    {
        uiManager = GetComponent<UIManager>();

        // 2P�� ó������ ��Ȱ��ȭ(2P���� �� 1P�Է� �Ϸ� �� Ȱ��ȭ)
        player2InputField.gameObject.SetActive(false);
        // �����޼��� ��� ��Ȱ��ȭ
        errorMessage.SetActive(false);
       
        // InputField �Է�����
        player1InputField.characterLimit = maxNameLength;
        player2InputField.characterLimit = maxNameLength;

        // Confirm��ư 
        player1ConfirmButton.onClick.AddListener(OnPlayer1ConfirmButtonClicked);
        player2ConfirmButton.onClick.AddListener(OnPlayer2ConfirmButtonClicked);

    }


    // ��ǲ�ʵ� Ȱ��ȭ �޼���
    // TODO: isSolo�� true��� player1InputField�� �Է� �� ��ȿ�� ���� �� ConfirmButton ������ �����г�, plyer2InputField�� ��� ��Ȱ��ȭ
    //      �ݸ�, false��� ���� ���� �� player2InpuntFieldȰ��ȭ �׸��� �Է� �� ��ȿ�� ���� ���� ConfirmButton������ �����г�
    private void OnPlayer1ConfirmButtonClicked()
    {
        string player1Name = player1InputField.text;
        if (IsValidName(player1Name))
        {
            GameManager.Instance.SetName(player1Name, null);
            if(GameManager.Instance.isSolo)
            {
                uiManager.OpenPanel(PanelType.CharacterChoose);
                AudioManager.instance.PlaySfx(AudioManager.Sfx.DM28);
            }
            else
            {
                player2InputField.gameObject.SetActive(true);
                AudioManager.instance.PlaySfx(AudioManager.Sfx.DM28);
            }
        }
        else
        {
            DisplayErrorMessage("�̸��� 2���ڿ��� 5���� ���̿��� �մϴ�.");
        }

    }

    private void OnPlayer2ConfirmButtonClicked()
    {
        string player2Name = player2InputField.text;
        if ( IsValidName(player2Name))
        {
            GameManager.Instance.SetName(GameManager.Instance.GetPlayer1Name(), player2Name);
            uiManager.OpenPanel(PanelType.CharacterChoose);
        }
        else
        {
            DisplayErrorMessage("�̸��� 2���ڿ��� 5���� ���̿��� �մϴ�.");
        }
    }


    // ���ڼ��� ���� �̸� ��ȿ�� �Ǻ�
    private bool IsValidName(string name)
    {
        return name.Length >= minNameLength && name.Length <= maxNameLength;
    }

    // ���� �޼��� ���
    private void DisplayErrorMessage(string message)
    {
        errorMessageText.text = message;
        errorMessage.SetActive(true);
    }
}
