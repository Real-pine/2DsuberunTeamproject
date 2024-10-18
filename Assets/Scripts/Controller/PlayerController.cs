using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
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

    private void Update()
    {
        // ��������Ʈ ���� ��ȯ
        if (characterRigidbody.velocity.x > 0) characterRenderer.flipX = true;
        else if (characterRigidbody.velocity.x < 0) characterRenderer.flipX = false;
    }

    private void FixedUpdate()
    {
        player();
        animController.Move(characterRigidbody.velocity);
    }

    public void player()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) // �� ����Ű
        {
            movement += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S)) // �Ʒ� ����Ű
        {
            movement += Vector3.down;
        }
        if (Input.GetKey(KeyCode.A)) // ���� ����Ű
        {
            movement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D)) // ������ ����Ű
        {
            movement += Vector3.right;
        }

        // Rigidbody2D�� �ӵ� ����
        characterRigidbody.velocity = movement.normalized * Speed;
    }
}