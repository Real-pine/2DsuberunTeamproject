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
        // 캐릭터의 속도를 초기화
        Speed = character.Speed;
    }

    private void FixedUpdate()
    {
        player();
        animController.Move(characterRigidbody.velocity);

        // 스프라이트 방향 전환
        if (characterRigidbody.velocity.x > 0) characterRenderer.flipX = false;
        else if (characterRigidbody.velocity.x < 0) characterRenderer.flipX = true;
    }

    public void player()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow)) // 위 방향키
        {
            movement += Vector3.up;
        }
        if (Input.GetKey(KeyCode.DownArrow)) // 아래 방향키
        {
            movement += Vector3.down;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) // 왼쪽 방향키
        {
            movement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow)) // 오른쪽 방향키
        {
            movement += Vector3.right;
        }

        // Rigidbody2D의 속도 설정
        characterRigidbody.velocity = new Vector2(movement.x, movement.y).normalized * Speed;
    }
}
