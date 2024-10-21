using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanelUI : MonoBehaviour
{
    

    [SerializeField] private Button startButton;
    [SerializeField] private Button descriptionButton;
    [SerializeField] private Button rankingButton;
    [SerializeField] private Button optionButton;

    private void Start()
    {
        
        
        startButton.onClick.AddListener(OnClickStartButton);
        descriptionButton.onClick.AddListener(OnClickDescriptionButton);
        rankingButton.onClick.AddListener(OnClickRankingButton);
        optionButton.onClick.AddListener(OnClickOptionButton);
    }

    private void OnClickOptionButton()
    {
        UIManager.instance.OpenPanel(PanelType.Option);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.DM28);
    }

    private void OnClickStartButton()
    {
        UIManager.instance.OpenPanel(PanelType.HowManyPlay);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.DM28);
    }

    private void OnClickDescriptionButton()
    {
        UIManager.instance.OpenPanel(PanelType.Description);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.DM28);
    }

    private void OnClickRankingButton()
    {
        UIManager.instance.OpenPanel(PanelType.Ranking);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.DM28);
    }
}
