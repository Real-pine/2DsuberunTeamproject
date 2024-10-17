using System;
using UnityEngine;
using UnityEngine.TextCore.Text;

public enum CharacterType
{
    Black,
    Blue,
    Brown,
    White
}

public class Character : MonoBehaviour
{
    public readonly float FULLHP = 10.0f;

    public RectTransform front;
    public CharacterType characterType;

    private float hp = 10.0f;
    private float speed = 1.0f;
    private bool isDie = false;

    public void Awake()
    {
        setCharacter();
    }

    private void setCharacter()
    {
        switch (characterType)
        {
            case CharacterType.Black: speed = 15.0f; break;
            case CharacterType.Blue: speed = 17.0f; break;
            case CharacterType.Brown: speed = 13.0f; break;
            case CharacterType.White: speed = 20.0f; break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ObstacleInfo obstacleInfo = collision.GetComponent<ObstacleInfo>();

        if (collision.CompareTag("Obstacle"))
        {
            hp -= obstacleInfo.Damage;
            front.localScale = new Vector3(hp / FULLHP, 1.0f, 1.0f);

            if (hp <= 0)
            {
                isDie = true;
                Time.timeScale = 0.0f;
            }
        }
    }
}