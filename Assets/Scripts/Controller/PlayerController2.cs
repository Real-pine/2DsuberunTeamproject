using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{ 
    [SerializeField] float Speed = 5f;
    [SerializeField] float x; // 캐릭터가 시작 할 x 좌표 위치
    [SerializeField] float y; // 캐릭터가 시작 할 y 좌표 위치


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

        characterRigidbody.velocity = (new Vector2(x, y)).normalized * Speed * Time.deltaTime;
    }
}
