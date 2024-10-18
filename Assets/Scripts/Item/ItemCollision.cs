using UnityEngine;

public class ItemCollision : MonoBehaviour
{
    Item item;

    private void Awake()
    {
        item = GetComponent<Item>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CheckItemType(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void CheckItemType(GameObject playerObject)
    {
        Character character = playerObject.GetComponent<Character>();
        switch (item.ItemType)
        {
            case ItemType.HpRecovery: character.HpRecovery(); break;
            case ItemType.CharacterSpeedUp:character.CharacterSpeedUp(); break;
            case ItemType.ObstaSpeedDown: break;
        }
    }
}