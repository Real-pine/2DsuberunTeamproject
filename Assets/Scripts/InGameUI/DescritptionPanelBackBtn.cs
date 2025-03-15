using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescritptionPanelBackBtn : MonoBehaviour
{
    public GameObject OptionPanelBtn;
    public GameObject DescriptionPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickBackBtn()
    {
        OptionPanelBtn.SetActive(true);
        DescriptionPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
