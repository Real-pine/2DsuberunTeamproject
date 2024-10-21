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
        CharacterCollision characterCollision = playerObject.GetComponent<CharacterCollision>();
        switch (item.ItemType)
        {
            case ItemType.Chicken: characterCollision.HpRecovery(); break;
            case ItemType.Cheese: characterCollision.CharacterSpeedUp(); break;
            case ItemType.Fish: characterCollision.CharacterInvincible(); break;
        }
    }
}
