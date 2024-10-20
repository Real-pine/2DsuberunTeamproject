using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private float delay = 0.5f;

    private void Generate()
    {
        GameObject newObstacle = Instantiate(obstaclePrefab[Random.Range(0, obstaclePrefab.Length)]);
        newObstacle.transform.position = new Vector2(Random.Range(-5.5f, 5.5f), 6);

        //장애물 종류에 따라 데미지 다르게 설정할 것
        newObstacle.GetComponent<ObstacleCollision>().SetDamage(10);
    }

    private void Update()
    {
        if (delay > 0) delay -= Time.deltaTime;
        else
        {
            delay = 0.5f;
            Generate();
        }
    }
}
