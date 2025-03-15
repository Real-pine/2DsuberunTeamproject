using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpbtn : MonoBehaviour
{
    public GameObject SettingPanel; [SerializeField]
    public GameObject DescriptionPanel; [SerializeField]
    public GameObject OptionPanelBtn; [SerializeField]

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnclickHelpBtn()
    {
        SettingPanel.SetActive(false);
        DescriptionPanel.SetActive(true);
        OptionPanelBtn.SetActive(false);
        Time.timeScale = 0;
    }
}
