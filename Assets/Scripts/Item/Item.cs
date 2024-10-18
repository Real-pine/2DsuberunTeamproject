using UnityEngine;

public enum ItemType
{
    HpRecovery,
    CharacterSpeedUp,
    ObstaSpeedDown
}

public class Item : MonoBehaviour
{
    private float Speed { get; }
    public ItemType ItemType { get; }


    public Item(ItemType type, float speed = 10)
    {
        ItemType = type;
        Speed = speed;
    }
}