using UnityEngine;

public enum ItemType
{
    HpRecovery,
    CharacterSpeedUp,
    CharacterInvincible
}

public class Item : MonoBehaviour
{
    private float Speed { get; }
    public ItemType ItemType;


    public Item(ItemType type, float speed = 10)
    {
        ItemType = type;
        Speed = speed;
    }
}