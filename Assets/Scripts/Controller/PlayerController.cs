using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
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
        player();
        animController.Move(characterRigidbody.velocity);

        if (x > 0) characterRenderer.flipX = true;
        else if (x < 0) characterRenderer.flipX = false;
    }

    public void player()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) // 위 방향키
        {
            movement += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S)) // 아래 방향키
        {
            movement += Vector3.down;
        }
        if (Input.GetKey(KeyCode.A)) // 왼쪽 방향키
        {
            movement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D)) // 오른쪽 방향키
        {
            movement += Vector3.right;
        }

        characterRigidbody.velocity = (new Vector2(x, y)).normalized * Speed * Time.deltaTime;
    }
}