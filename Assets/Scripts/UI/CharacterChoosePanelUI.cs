using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChoosePanelUI : MonoBehaviour
{
    [SerializeField] private Button Character1;
    [SerializeField] private Button Character2;
    [SerializeField] private Button Character3;
    [SerializeField] private Button Character4;
    [SerializeField] private Button NextButton;

    [SerializeField] private Image Player1Selected;
    [SerializeField] private Image Player2Selected;

    [SerializeField] private Sprite[] characterSprites;

    // 2P모드일 때, 1P가 선택되었는지 확인하는 bool값
    private bool isPlayer1Selected = false;
   
    private void Start()
    {
        NextButton.gameObject.SetActive(false);

        // 버튼들에 리스너 등록
        Character1.onClick.AddListener(() => SelectCharacter(CharacterType.Black));
        Character2.onClick.AddListener(() => SelectCharacter(CharacterType.Blue));
        Character3.onClick.AddListener(() => SelectCharacter(CharacterType.Brown));
        Character4.onClick.AddListener(() => SelectCharacter(CharacterType.White));

        NextButton.onClick.AddListener(OnClickNextButton);
    }

    //TODO: isSolo가 true라면 1P 선택된 player1Character에 캐릭터가 저장되어야함, 그리고 Player1Selected UI에 선택한 캐릭터 이미지를 넣어야함
    //      GameManager에 SetPlayerCharacter를 만들어야할듯
    //      isSolo가 false라면 1P선택후 저장, UI에 이미지출력. 그리고나서 2P선택 후 저장 UI에 이미지 출력하고 NextButton활성화
    //      중요한건 캐릭터 타입에 맞게 저장이 되어야함 게임매니저에
    private void SelectCharacter(CharacterType selectedCharacter)
    {
        if(GameManager.Instance.isSolo) // 1P모드
        {
            // 1P 캐릭터 선택 및 저장
            GameManager.Instance.SetPlayerCharacter(1, (int)selectedCharacter);
            Player1Selected.sprite = characterSprites[(int)selectedCharacter];
            AudioManager.instance.PlaySfx(AudioManager.Sfx.DM28);
            //바로 넥스트 버튼 활성화
            NextButton.gameObject.SetActive(true);
        }
        else // 2P모드
        {
            // 1P 선택 중
            if (!isPlayer1Selected) 
            {
                GameManager.Instance.SetPlayerCharacter(1, (int)selectedCharacter);
                Player1Selected.sprite = characterSprites[(int)selectedCharacter];
                AudioManager.instance.PlaySfx(AudioManager.Sfx.DM28);
                isPlayer1Selected =true;
            }
            // 2P 선택 중
            else
            {
                GameManager.Instance.SetPlayerCharacter(2, (int)selectedCharacter);
                Player2Selected.sprite = characterSprites[(int)selectedCharacter];
                AudioManager.instance.PlaySfx(AudioManager.Sfx.DM28);
                NextButton.gameObject.SetActive(true);
            }
        }
    }

    private void OnClickNextButton()
    {
        UIManager.instance.OpenPanel(PanelType.SelectStage);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.DM28);
    }
}   
