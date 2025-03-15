using UnityEngine;
using System.Collections;

public class CharacterCollision : MonoBehaviour
{
    public readonly float UPSPEED = 0.2f;
    public readonly float DURATIONTIME = 5.0f;

    private Character character;
    private Coroutine hitCoroutine;

    private bool isInvincible = false;
    //피격 시 잠시 무적
    private bool isHit = false;
    private bool isDie = false;
    private float hitDelay = 0.2f;

    private SpriteRenderer sprite;

    private void Awake()
    {
        character = GetComponent<Character>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void HitCharacter(float damage)
    {
        if (isInvincible || isHit) return;
        character.SetHp(character.Hp - damage);
        character.UpdateHpBar();
        isHit = true;
        sprite.color = Color.red;

        if (hitCoroutine != null) StopCoroutine(hitCoroutine);
        hitCoroutine = StartCoroutine(HitInvincible());

        if (character.Hp <= 0)
        {
            isDie = true;
            Destroy(gameObject);
            GameManager.Instance.OnPlayerDeath();
        }
    }

    public void HpRecovery()
    {
        float newHp = Mathf.Min(character.Hp + 10.0f, Character.FULLHP);
        character.SetHp(newHp);
        character.UpdateHpBar();
    }

    public void CharacterSpeedUp()
    {
        character.SetSpeed(character.Speed * UPSPEED);
        StartCoroutine(ResetSpeed());
    }

    private IEnumerator ResetSpeed()
    {
        yield return new WaitForSeconds(DURATIONTIME);
        character.SetSpeed(character.GetInitialSpeed());
    }

    public void CharacterInvincibility()
    {
        isInvincible = true;
        sprite.color = Color.yellow;
        StartCoroutine(ResetInvincibility());
    }

    private IEnumerator ResetInvincibility()
    {
        yield return new WaitForSeconds(DURATIONTIME);
        isInvincible = false;
        sprite.color = Color.white;
    }

    private IEnumerator HitInvincible()
    {
        yield return new WaitForSeconds(hitDelay);
        isHit = false;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}