using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField] float Speed = 5f;

    private AnimationController animController;
    private Character character;

    [SerializeField] Rigidbody2D characterRigidbody;
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
        // ĳ������ �ӵ��� �ʱ�ȭ
        Speed = character.Speed;
    }

    private void FixedUpdate()
    {
        player();
        animController.Move(characterRigidbody.velocity);

        // ��������Ʈ ���� ��ȯ
        if (characterRigidbody.velocity.x > 0) characterRenderer.flipX = false;
        else if (characterRigidbody.velocity.x < 0) characterRenderer.flipX = true;
    }

    public void player()
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

        // Rigidbody2D�� �ӵ� ����
        characterRigidbody.velocity = new Vector2(movement.x, movement.y).normalized * Speed;
    }
}