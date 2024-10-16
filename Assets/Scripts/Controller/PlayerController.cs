using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float y;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, y);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        //x�࿡ ���� �̵� �ڵ�
        transform.position += (new Vector3(x, 0)).normalized * Time.deltaTime * Speed;
        //speed(�̵� �ӵ�)�� �ӵ��� �յ��ϰ� �ϴ� normalized�� ����� ��ġ�� ������Ʈ
    }
}
