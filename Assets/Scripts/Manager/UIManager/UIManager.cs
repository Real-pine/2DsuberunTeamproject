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
    // TODO: GetBack버튼 프리팹
    [SerializeField] private GameObject getBackButtonPrefab;

    // 패널을 열거형 순서에 맞춰 배열로 저장
    [SerializeField] private GameObject[] panels;

    // 패널 기록 스택(겟백 프리팹 사용 시 스택형으로 미리 히스토리 저장)
    [SerializeField] private Stack<PanelType> panelHistory = new Stack<PanelType>();
    // 생성된 GetBackButton을 저장할 변수
    private GameObject activeGetBackButton;

    private void Start()
    {
        // 시작 Start패널 여는걸로
        OpenPanel(PanelType.Start);
    }

    // 패널 열기
    public void OpenPanel(PanelType panelType)
    {
        int index = (int)panelType;

        if(panelHistory.Count > 0)
        {
            PanelType currentPanelType = panelHistory.Peek();
            // 이전 패널 비활성화
            panels[(int)currentPanelType].SetActive(false);
        }

        // 선택한 패널 활성화
        panels[index].SetActive(true);
        // 패널 기록 저장
        panelHistory.Push(panelType);

        if (panelType != PanelType.Start)
        // GetBack버튼 생성(Start 패널에서는 Back버튼이 필요 없으므로 제외
        {
            CreateGetBackButton(panels[index]);
        }
    }

    // GetBackButton 생성 및 부모Canvas 자동 탐색
    private void CreateGetBackButton(GameObject panel)
    {
        // 이전에 생서된 GetBackButton이 있다면 제거
        if(activeGetBackButton != null)
        {
            Destroy(activeGetBackButton);
        }
        
        // 부모Canvas 찾기
        Canvas parentCanvas = panel.GetComponentInParent<Canvas>();
        if(parentCanvas == null)
        {
            parentCanvas = FindObjectOfType<Canvas>(); // 없으면 첫 번째 Canvas탐색
        }

        // Back 버튼 생성 후 부모에 배치
        activeGetBackButton = Instantiate(getBackButtonPrefab, parentCanvas.transform);
        activeGetBackButton.GetComponent<Button>().onClick.AddListener(()  => GetBack(panel));
    }

    private void GetBack(GameObject currentPanel)
    {
        if (panelHistory.Count > 1)
        {
            // 현재 패널 닫기
            currentPanel.SetActive(false);
            panelHistory.Pop();

            // 직전 패널 꺼내오기
            PanelType previousPanelType = panelHistory.Peek();
            // 직전 패널 활성화
            panels[(int)previousPanelType].SetActive(true);

            if (activeGetBackButton != null)
            {
                Destroy(activeGetBackButton);
                activeGetBackButton = null;
            }
        }
    }
}
