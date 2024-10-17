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

    public RectTransform front;
    public CharacterType characterType;

    private float hp = 100.0f;
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
        front.localScale = new Vector3(hp / FULLHP, 1.0f, 1.0f);
    }

    public void HitCharacter(float damage)
    {
        hp -= damage;
        front.localScale = new Vector3(hp / FULLHP, 1.0f, 1.0f);

        if (hp <= 0)
        {
            isDie = true;
            Time.timeScale = 0.0f;
        }

        Debug.Log(hp);
    }
}