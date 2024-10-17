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

    [SerializeField] private RectTransform front;
    [SerializeField] private CharacterType characterType;

    private AnimationController animController;
    private float hp = 100.0f;
    private bool isDie = false;
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
        Debug.Log(Speed);
    }

    public void HitCharacter(float damage)
    {
        hp -= damage;
        front.localScale = new Vector3(hp / FULLHP, 1.0f, 1.0f);
        animController.Hit();

        if (hp <= 0)
        {
            isDie = true;
            Time.timeScale = 0.0f;
        }
    }
}
