using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    public GameObject[] characters;

    private void Generate()
    {
        if (GameManager.Instance.isSolo)
        {
            GameObject newPlayer1 = Instantiate(characters[GameManager.Instance.player1Character]);
            newPlayer1.transform.position = new Vector2(0, -4);
            newPlayer1.GetComponent<Character>().setCharacter(1);
        }
        else
        {
            GameObject newPlayer1 = Instantiate(characters[GameManager.Instance.player1Character]);
            newPlayer1.transform.position = new Vector2(-4, -4);
            newPlayer1.GetComponent<Character>().setCharacter(1);

            GameObject newPlayer2 = Instantiate(characters[GameManager.Instance.player2Character]);
            newPlayer2.transform.position = new Vector2(4, -4);
            newPlayer2.GetComponent<Character>().setCharacter(2);
        }
    }

    private void OnEnable()
    {
        Generate();
    }
}
