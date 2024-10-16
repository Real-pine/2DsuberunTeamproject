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
        //x축에 대한 이동 코드
        transform.position += (new Vector3(x, 0)).normalized * Time.deltaTime * Speed;
        //speed(이동 속도)와 속도를 균등하게 하는 normalized를 사용해 위치를 업데이트
    }
}
