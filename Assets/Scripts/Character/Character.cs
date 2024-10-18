using System.Collections;
using UnityEngine;

public enum CharacterType
{
    Black,
    Blue,
    Brown,
    White
}

public class Character : MonoBehaviour
{
    public readonly float FULLHP = 100.0f;
    public readonly float DURATIONTIME = 5.0f;
    public readonly float UPSPEED = 0.2f;

    [SerializeField] private RectTransform front;
    [SerializeField] private CharacterType characterType;

    private AnimationController animController;
    private float hp = 100.0f;
    private bool isDie = false;
    private bool isInvincible = false;

    //피격 시 잠시 무적
    private bool isHit = false;
    private float hitDelay = 1.0f;
    private Coroutine hitCoroutine;

    public float Speed { get; private set; }

    public void Awake()
    {
        animController = GetComponent<AnimationController>();
        setCharacter();
    }

    private void setCharacter()
    {
        switch (characterType)
        {
            case CharacterType.Black: Speed = 10.0f; break;
            case CharacterType.Blue: Speed = 9.0f; break;
            case CharacterType.Brown: Speed = 9.5f; break;
            case CharacterType.White: Speed = 10.5f; break;
        }
        front.localScale = new Vector3(hp / FULLHP, 1.0f, 1.0f);
    }

    public void HitCharacter(float damage)
    {
        if (isInvincible || isHit) return;
        hp -= damage;
        front.localScale = new Vector3(hp / FULLHP, 1.0f, 1.0f);
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
    }

    public void CharacterSpeedUp()
    {
        float prevSpeed = Speed;
        Speed += Speed * UPSPEED;
        StartCoroutine(ResetSpeed(prevSpeed));
    }

    private IEnumerator ResetSpeed(float prevSpeed)
    {
        yield return new WaitForSeconds(DURATIONTIME);
        Speed = prevSpeed;
    }

    public void CharacterInvincible()
    {
        StartCoroutine(ResetInvincible());
    }

    private IEnumerator ResetInvincible()
    {
        yield return new WaitForSeconds(DURATIONTIME);
        isInvincible = false;
    }
    private IEnumerator Hit_Invincible()
    {
        yield return new WaitForSeconds(hitDelay);
        isHit = false;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}
