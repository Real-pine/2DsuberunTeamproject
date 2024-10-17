using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PanelType
{
    Start,
    Ranking,
    HowManyPlay,
    Description,
    Option,
    InputPlayerName,
    CharacterChoose,
    SelectStage
}

public class UIManager : MonoBehaviour
{
    // TODO: GetBack��ư ������
    [SerializeField] private GameObject getBackButtonPrefab;

    // �г��� ������ ������ ���� �迭�� ����
    [SerializeField] private GameObject[] panels;

    // �г� ��� ����(�ٹ� ������ ��� �� ���������� �̸� �����丮 ����)
    [SerializeField] private Stack<PanelType> panelHistory = new Stack<PanelType>();
    // ������ GetBackButton�� ������ ����
    private GameObject activeGetBackButton;

    private void Start()
    {
        // ���� Start�г� ���°ɷ�
        OpenPanel(PanelType.Start);
    }

    // �г� ����
    public void OpenPanel(PanelType panelType)
    {
        int index = (int)panelType;

        if(panelHistory.Count > 0)
        {
            PanelType currentPanelType = panelHistory.Peek();
            // ���� �г� ��Ȱ��ȭ
            panels[(int)currentPanelType].SetActive(false);
        }

        // ������ �г� Ȱ��ȭ
        panels[index].SetActive(true);
        // �г� ��� ����
        panelHistory.Push(panelType);

        if (panelType != PanelType.Start)
        // GetBack��ư ����(Start �гο����� Back��ư�� �ʿ� �����Ƿ� ����
        {
            CreateGetBackButton(panels[index]);
        }
    }

    // GetBackButton ���� �� �θ�Canvas �ڵ� Ž��
    private void CreateGetBackButton(GameObject panel)
    {
        // ������ ������ GetBackButton�� �ִٸ� ����
        if(activeGetBackButton != null)
        {
            Destroy(activeGetBackButton);
        }
        
        // �θ�Canvas ã��
        Canvas parentCanvas = panel.GetComponentInParent<Canvas>();
        if(parentCanvas == null)
        {
            parentCanvas = FindObjectOfType<Canvas>(); // ������ ù ��° CanvasŽ��
        }

        // Back ��ư ���� �� �θ� ��ġ
        activeGetBackButton = Instantiate(getBackButtonPrefab, parentCanvas.transform);
        activeGetBackButton.GetComponent<Button>().onClick.AddListener(()  => GetBack(panel));
    }

    private void GetBack(GameObject currentPanel)
    {
        if (panelHistory.Count > 1)
        {
            // ���� �г� �ݱ�
            currentPanel.SetActive(false);
            panelHistory.Pop();

            // ���� �г� ��������
            PanelType previousPanelType = panelHistory.Peek();
            // ���� �г� Ȱ��ȭ
            panels[(int)previousPanelType].SetActive(true);

            if (activeGetBackButton != null)
            {
                Destroy(activeGetBackButton);
                activeGetBackButton = null;
            }
        }
    }
}
