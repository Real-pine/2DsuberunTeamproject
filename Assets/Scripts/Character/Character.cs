﻿using UnityEngine;
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
    public readonly float FULLHP = 100.0f;
    public readonly float DURATIONTIME = 5.0f;
    public readonly float UPSPEED = 0.2f;

    [SerializeField] private RectTransform front;
    [SerializeField] private CharacterType characterType;

    private AnimationController animController;
    private float hp = 100.0f;
    private bool isDie = false;
    private bool isInvincible = false;

    private Dictionary<string, float> initialSpeed = new Dictionary<string, float>
    { { "Black", 10.0f }, { "Blue", 9.0f }, { "Brown", 9.5f }, { "White", 10.5f } };

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
            case CharacterType.Black: Speed = initialSpeed[characterType.ToString()]; break;
            case CharacterType.Blue: Speed = initialSpeed[characterType.ToString()]; break;
            case CharacterType.Brown: Speed = initialSpeed[characterType.ToString()]; break;
            case CharacterType.White: Speed = initialSpeed[characterType.ToString()]; break;
        }
        front.localScale = new Vector3(hp / FULLHP, 1.0f, 1.0f);
    }

    public void HitCharacter(float damage)
    {
        if (isInvincible) return;
        hp -= damage;
        front.localScale = new Vector3(hp / FULLHP, 1.0f, 1.0f);
        animController.Hit();

        if (hp <= 0)
        {
            isDie = true;
            Time.timeScale = 0.0f;
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
        StartCoroutine(ResetInvincible());
    }

    private IEnumerator ResetInvincible()
    {
        yield return new WaitForSeconds(DURATIONTIME);
        isInvincible = false;
    }
}
