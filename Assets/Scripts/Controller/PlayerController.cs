using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private AnimationController animController;
    private Character character;
    
    private Rigidbody2D characterRigidbody;
    private SpriteRenderer characterRenderer;

    private float speed;
    private float y;

    private void Awake()
    {
        animController = GetComponent<AnimationController>();
        character = GetComponent<Character>();
        characterRigidbody = GetComponent<Rigidbody2D>();
        characterRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        y = character.transform.position.y;
        transform.position = new Vector3(0, y);
        speed = character.Speed;
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        //x�࿡ ���� �̵� �ڵ�
        characterRigidbody.velocity = (new Vector2(x, 0)).normalized * speed;
        //speed(�̵� �ӵ�)�� �ӵ��� �յ��ϰ� �ϴ� normalized�� ����� ��ġ�� ������Ʈ
        animController.Move(characterRigidbody.velocity);

        if (x > 0) characterRenderer.flipX = true;
        else if (x < 0) characterRenderer.flipX = false;
    }
}