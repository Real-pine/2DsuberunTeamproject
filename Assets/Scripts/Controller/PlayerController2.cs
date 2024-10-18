using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float x; // ĳ���Ͱ� ���� �� x ��ǥ ��ġ
    [SerializeField] float y; // ĳ���Ͱ� ���� �� y ��ǥ ��ġ
   
    void Start()
    {
        transform.position = new Vector3(x, y);
        //ĳ������ ��ġ ����
    }


    void Update()
    {
        player2();
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

        transform.position += (Vector3)movement.normalized * Time.deltaTime * Speed;
    }
}
