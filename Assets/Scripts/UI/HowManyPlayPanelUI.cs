using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowManyPlayPanel : MonoBehaviour
{

    [SerializeField] private Button Player1PButton;
    [SerializeField] private Button Player2PButton;

    private void Start()
    {
        Player1PButton.onClick.AddListener(() => SetPlayerMode(true));
        Player2PButton.onClick.AddListener(() => SetPlayerMode(false));
    }

    // TODO : 플레이어 수를 데이터저장하는 메서드를 작성해야할 듯
    private void SetPlayerMode(bool _isSolo)
    {
        GameManager.Instance.SetSolo(_isSolo);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.DM28);
        //다음 패널로 전환
        UIManager.instance.OpenPanel(PanelType.InputPlayerName);
    }
}
