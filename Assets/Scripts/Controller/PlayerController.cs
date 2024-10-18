using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float x; // 캐릭터가 시작 할 x 좌표 위치
    [SerializeField] float y; // 캐릭터가 시작 할 y 좌표 위치
    
    void Start()
    {
        transform.position = new Vector3(x, y);
        //캐릭터의 위치 지정
    }

    void Update()
    {
        player1();
    }

    public void player1()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) // W 키
        {
            movement += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S)) // S 키
        {
            movement += Vector3.down;
        }
        if (Input.GetKey(KeyCode.A)) // A 키
        {
            movement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D)) // D 키
        {
            movement += Vector3.right;
        }

        transform.position += (Vector3)movement.normalized * Time.deltaTime * Speed;
    }
}
