using UnityEngine;
using System.Collections;
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

    public static readonly float FULLHP = 100.0f;
    public readonly float DURATIONTIME = 5.0f;
    public readonly float UPSPEED = 0.2f;

    [SerializeField] private RectTransform front;
    [SerializeField] private CharacterType characterType;

    private AnimationController animController;
    private float hp = FULLHP;
    private bool isDie = false;
    private bool isInvincible = false;

    private Dictionary<string, float> initialSpeed = new Dictionary<string, float>
    { { "Black", 10.0f }, { "Blue", 9.0f }, { "Brown", 9.5f }, { "White", 10.5f } };

    //피격 시 잠시 무적
    private bool isHit = false;
    private float hitDelay = 1.0f;
    private Coroutine hitCoroutine;

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

    public void HitCharacter(float damage)
    {
        if (isInvincible || isHit) return;
        hp -= damage;
        UpdateHpBar();
        isHit = true;
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
        if (hitCoroutine != null) StopCoroutine(hitCoroutine);
        hitCoroutine = StartCoroutine("Hit_Invincible");

        if (hp <= 0)
        {
            isDie = true;
            GameManager.Instance.OnPlayerDeath();
        }
    }

    public void HpRecovery()
    {
        hp += 10.0f;
        if(hp > FULLHP)
        {
            hp = FULLHP;
        }
        UpdateHpBar();
    }

    public void UpdateHpBar()
    {
        front.localScale = new Vector3(hp / FULLHP, 1.0f, 1.0f);
    }

    public void CharacterSpeedUp()
    {
        Speed += Speed * UPSPEED;
        StartCoroutine(ResetSpeed());
    }

    private IEnumerator ResetSpeed()
    {
        yield return new WaitForSeconds(DURATIONTIME);
        Speed = initialSpeed[characterType.ToString()];
    }

    public void CharacterInvincible()
    {
        isInvincible = true;
        GetComponent<SpriteRenderer>().color = Color.yellow;
        StartCoroutine(ResetInvincible());
    }

    private IEnumerator ResetInvincible()
    {
        yield return new WaitForSeconds(DURATIONTIME);
        isInvincible = false;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    private IEnumerator Hit_Invincible()
    {
        yield return new WaitForSeconds(hitDelay);
        isHit = false;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}
