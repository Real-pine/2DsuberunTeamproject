using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleInfo : MonoBehaviour
{
    public float Speed { get; }
    public float Damage { get; }

    public ObstacleInfo(float _speed = 10, float _damage = 0)
    {
        Speed = _speed;
        Damage = _damage;
    }
}
