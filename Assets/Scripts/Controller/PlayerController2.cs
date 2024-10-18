using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
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
        player2();
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

        transform.position += (Vector3)movement.normalized * Time.deltaTime * Speed;
    }
}
