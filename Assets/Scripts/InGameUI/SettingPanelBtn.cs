using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanelBtn : MonoBehaviour
{

    public GameObject SettingPanel; [SerializeField]
    public GameObject OptionPanel; [SerializeField]
 

    public void OpenSettingPanel()
    {
        OptionPanel.SetActive(false);
        SettingPanel.SetActive(true);

        if (SettingPanel.activeSelf)
        {
            Time.timeScale = 0;
        }

        else
        {
            Time.timeScale = 1;
        }


    }
}
