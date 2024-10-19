using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            case ItemType.Chicken: character.HpRecovery(); break;
            case ItemType.Cheese:character.CharacterSpeedUp(); break;
            case ItemType.Fish: character.CharacterInvincible(); break;
        }
    }
}
