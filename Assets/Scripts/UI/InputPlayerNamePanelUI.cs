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

    // �̸� ���ڼ� ����
    private int minNameLength = 2;
    private int maxNameLength = 5;

    private void Start()
    {
        // �����޼��� ��� ��Ȱ��ȭ
        errorMessage.SetActive(false);
        // TODO: HowManyPlay���� Player1�� �����ߴٸ� Player2��Ȱ��ȭ �޼���
        ActivateInputField();
        // InputField �Է�����
        player1InputField.characterLimit = maxNameLength;
        player2InputField.characterLimit = maxNameLength;

        // Confirm��ư 
        //player1ConfirmButton.onClick.AddListener(OnConfirmButtonClicked);
        //player2ConfirmButton.onClick.AddListener(OnConfirmButtonClicked);

        // 
    }

    // ��ǲ�ʵ� Ȱ��ȭ �޼���
    private void ActivateInputField()
    {
        // TODO : 
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
