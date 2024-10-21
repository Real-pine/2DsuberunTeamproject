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

    // 2P����� ��, 1P�� ���õǾ����� Ȯ���ϴ� bool��
    private bool isPlayer1Selected = false;
   
    private void Start()
    {
        NextButton.gameObject.SetActive(false);

        // ��ư�鿡 ������ ���
        Character1.onClick.AddListener(() => SelectCharacter(CharacterType.Black));
        Character2.onClick.AddListener(() => SelectCharacter(CharacterType.Blue));
        Character3.onClick.AddListener(() => SelectCharacter(CharacterType.Brown));
        Character4.onClick.AddListener(() => SelectCharacter(CharacterType.White));

        NextButton.onClick.AddListener(OnClickNextButton);
    }

    //TODO: isSolo�� true��� 1P ���õ� player1Character�� ĳ���Ͱ� ����Ǿ����, �׸��� Player1Selected UI�� ������ ĳ���� �̹����� �־����
    //      GameManager�� SetPlayerCharacter�� �������ҵ�
    //      isSolo�� false��� 1P������ ����, UI�� �̹������. �׸����� 2P���� �� ���� UI�� �̹��� ����ϰ� NextButtonȰ��ȭ
    //      �߿��Ѱ� ĳ���� Ÿ�Կ� �°� ������ �Ǿ���� ���ӸŴ�����
    private void SelectCharacter(CharacterType selectedCharacter)
    {
        if(GameManager.Instance.isSolo) // 1P���
        {
            // 1P ĳ���� ���� �� ����
            GameManager.Instance.SetPlayerCharacter(1, (int)selectedCharacter);
            Player1Selected.sprite = characterSprites[(int)selectedCharacter];
            AudioManager.instance.PlaySfx(AudioManager.Sfx.DM28);
            //�ٷ� �ؽ�Ʈ ��ư Ȱ��ȭ
            NextButton.gameObject.SetActive(true);
        }
        else // 2P���
        {
            // 1P ���� ��
            if (!isPlayer1Selected) 
            {
                GameManager.Instance.SetPlayerCharacter(1, (int)selectedCharacter);
                Player1Selected.sprite = characterSprites[(int)selectedCharacter];
                AudioManager.instance.PlaySfx(AudioManager.Sfx.DM28);
                isPlayer1Selected =true;
            }
            // 2P ���� ��
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
