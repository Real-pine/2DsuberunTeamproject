using UnityEngine;

public class Item : MonoBehaviour
{
    public float Speed { get; }

    public Item(float speed = 10, float damage = 0)
    {
        Speed = speed;
    }
}