using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeBtn : MonoBehaviour
{
    public GameObject SettingPanel; [SerializeField]
    public GameObject OptionPanel; [SerializeField]

    public void ClickResumeBtn()
    {
        SettingPanel.SetActive(false);
        OptionPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    
}
