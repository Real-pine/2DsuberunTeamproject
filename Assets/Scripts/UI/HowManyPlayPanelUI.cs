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
        // TODO : 리스너로 1P인지 2P인지 판단하는 이벤트 연결
        // TODO : 플레이어 수 데이터를 넘겨주는 이벤트 연결
    }

    private void OnClickToInputPlayerName()
    {
        uiManager.OpenPanel(PanelType.InputPlayerName);
    }

    // TODO : 1P인지 2P인지 판단하는 함수(OnClickToInputPlayerName()메서드에 병합해도 될듯?)

    // TODO : 플레이어 수를 캐릭터 데이터에 넘겨줘야하는 메서드를 작성해야할 듯
}
