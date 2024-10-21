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

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    public void HitCharacter(float damage)
    {
        if (isInvincible || isHit) return;
        character.SetHp(character.Hp - damage);
        character.UpdateHpBar();
        isHit = true;
        GetComponent<SpriteRenderer>().color = Color.red;
        if (hitCoroutine != null) StopCoroutine(hitCoroutine);
        hitCoroutine = StartCoroutine("Hit_Invincible");

        if (character.Hp <= 0)
        {
            isDie = true;
            GameManager.Instance.OnPlayerDeath();
        }
    }

    public void HpRecovery()
    {
        character.SetHp(character.Hp + 10.0f);
        if (character.Hp > Character.FULLHP)
        {
            character.SetHp(Character.FULLHP);
        }
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
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}