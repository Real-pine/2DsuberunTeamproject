using UnityEngine;
using System.Collections.Generic;

public enum CharacterType
{
    Black,
    Blue,
    Brown,
    White
}

public class Character : MonoBehaviour
{
    public int playerNumber { get; private set; }

    public static readonly float FULLHP = 50.0f;

    [SerializeField] private RectTransform front;
    [SerializeField] private CharacterType characterType;

    private AnimationController animController;

    private Dictionary<string, float> initialSpeed = new Dictionary<string, float>
    { { "Black", 10.0f }, { "Blue", 9.0f }, { "Brown", 9.5f }, { "White", 10.5f } };

    public float Hp { get; private set; } = FULLHP;

    public float Speed { get; private set; }

    public void Awake()
    {
        animController = GetComponent<AnimationController>();
    }

    public void setCharacter(int _playerNumber)
    {
        playerNumber = _playerNumber;
        switch (characterType)
        {
            case CharacterType.Black: Speed = initialSpeed[characterType.ToString()]; break;
            case CharacterType.Blue: Speed = initialSpeed[characterType.ToString()]; break;
            case CharacterType.Brown: Speed = initialSpeed[characterType.ToString()]; break;
            case CharacterType.White: Speed = initialSpeed[characterType.ToString()]; break;
        }
        UpdateHpBar();
    }

    public void SetHp(float changeHp)
    {
        Hp = changeHp;
    }

    public void SetSpeed(float changeSpeed)
    {
        Speed = changeSpeed;
    }

    public float GetInitialSpeed()
    {
        return initialSpeed[characterType.ToString()];
    }

    public void UpdateHpBar()
    {
        front.localScale = new Vector3(Hp / FULLHP, 1.0f, 1.0f);
    }
}
