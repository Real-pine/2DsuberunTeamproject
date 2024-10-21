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

    private UIManager uiManager;

    // 이름 글자수 제한
    private int minNameLength = 2;
    private int maxNameLength = 5;

    private void Start()
    {
        uiManager = GetComponent<UIManager>();

        // 2P는 처음부터 비활성화(2P선택 시 1P입력 완료 후 활성화)
        player2InputField.gameObject.SetActive(false);
        // 에러메세지 출력 비활성화
        errorMessage.SetActive(false);
       
        // InputField 입력제한
        player1InputField.characterLimit = maxNameLength;
        player2InputField.characterLimit = maxNameLength;

        // Confirm버튼 
        player1ConfirmButton.onClick.AddListener(OnPlayer1ConfirmButtonClicked);
        player2ConfirmButton.onClick.AddListener(OnPlayer2ConfirmButtonClicked);

    }


    // 인풋필드 활성화 메서드
    // TODO: isSolo가 true라면 player1InputField에 입력 후 유효성 검증 후 ConfirmButton 누르면 다음패널, plyer2InputField는 계속 비활성화
    //      반면, false라면 위의 과정 후 player2InpuntField활성화 그리고 입력 후 유효성 검증 다음 ConfirmButton누르면 다음패널
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
            DisplayErrorMessage("이름은 2글자에서 5글자 사이여야 합니다.");
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
            DisplayErrorMessage("이름은 2글자에서 5글자 사이여야 합니다.");
        }
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
