using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ObstacleCollision: MonoBehaviour
{
    private float Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //collision.GetComponent�� ���� Damage��ŭ ���� ������
            Destroy(gameObject);
        }
    }
}
