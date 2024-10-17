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

    //에러 메세지
    [SerializeField] private GameObject errorMessage;
    [SerializeField] private TMP_Text errorMessageText;

    // 이름 글자수 제한
    private int minNameLength = 2;
    private int maxNameLength = 5;

    private void Start()
    {
        // 에러메세지 출력 비활성화
        errorMessage.SetActive(false);
        // TODO: HowManyPlay에서 Player1을 선택했다면 Player2비활성화 메서드
        ActivateInputField();
        // InputField 입력제한
        player1InputField.characterLimit = maxNameLength;
        player2InputField.characterLimit = maxNameLength;

        // Confirm버튼 
        //player1ConfirmButton.onClick.AddListener(OnConfirmButtonClicked);
        //player2ConfirmButton.onClick.AddListener(OnConfirmButtonClicked);

        // 
    }

    // 인풋필드 활성화 메서드
    private void ActivateInputField()
    {
        // TODO : 
    }



    // 글자수에 따른 이름 유효성 판별
    private bool IsValidName(string name)
    {
        return name.Length >= minNameLength && name.Length <= maxNameLength;
    }

    // 에러 메세지 출력
    private void DisplayErrorMessage(string message)
    {
        errorMessageText.text = message;
        errorMessage.SetActive(true);
    }


}
