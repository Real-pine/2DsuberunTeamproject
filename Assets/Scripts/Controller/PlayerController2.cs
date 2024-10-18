using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{ 
    [SerializeField] float Speed = 5f;
    [SerializeField] float x; // ĳ���Ͱ� ���� �� x ��ǥ ��ġ
    [SerializeField] float y; // ĳ���Ͱ� ���� �� y ��ǥ ��ġ


    private AnimationController animController;
    private Character character;

    private Rigidbody2D characterRigidbody;
    private SpriteRenderer characterRenderer;

    private void Awake()
    {
        animController = GetComponent<AnimationController>();
        character = GetComponent<Character>();
        characterRigidbody = GetComponent<Rigidbody2D>();
        characterRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        x = character.transform.position.x;
        y = character.transform.position.y;
        transform.position = new Vector3(x, y);
        Speed = character.Speed;
    }

    private void FixedUpdate()
    {
        player2();
        animController.Move(characterRigidbody.velocity);

        if (x > 0) characterRenderer.flipX = true;
        else if (x < 0) characterRenderer.flipX = false;
    }

    public void player2()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow)) // �� ����Ű
        {
            movement += Vector3.up;
        }
        if (Input.GetKey(KeyCode.DownArrow)) // �Ʒ� ����Ű
        {
            movement += Vector3.down;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) // ���� ����Ű
        {
            movement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow)) // ������ ����Ű
        {
            movement += Vector3.right;
        }

        characterRigidbody.velocity = (new Vector2(x, y)).normalized * Speed * Time.deltaTime;
    }
}
