using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanelUI : MonoBehaviour
{
    private UIManager uiManager;

    [SerializeField] private Button startButton;
    [SerializeField] private Button descriptionButton;
    [SerializeField] private Button rankingButton;
    [SerializeField] private Button optionButton;

    private void Start()
    {
        uiManager = GetComponent<UIManager>();
        
        startButton.onClick.AddListener(OnClickStartButton);
        descriptionButton.onClick.AddListener(OnClickDescriptionButton);
        rankingButton.onClick.AddListener(OnClickRankingButton);
        optionButton.onClick.AddListener(OnClickOptionButton);
    }

    private void OnClickOptionButton()
    {
        uiManager.OpenPanel(PanelType.Option);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.DM28);
    }

    private void OnClickStartButton()
    {
        uiManager.OpenPanel(PanelType.HowManyPlay);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.DM28);
    }

    private void OnClickDescriptionButton()
    {
        uiManager.OpenPanel(PanelType.Description);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.DM28);
    }

    private void OnClickRankingButton()
    {
        uiManager.OpenPanel(PanelType.Ranking);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.DM28);
    }
}
