using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ObstacleCollision: MonoBehaviour
{
    private float Damage;

    public void SetDamage(float damage)
    {
        Damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //collision.GetComponent�� ���� Damage��ŭ ���� ������
            collision.GetComponent<Character>().HitCharacter(Damage);
            Destroy(gameObject);
        }
    }
}
