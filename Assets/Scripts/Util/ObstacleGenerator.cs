using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private float delay = 1;

    private void Generate()
    {
        GameObject newObstacle = Instantiate(obstaclePrefab);
        newObstacle.transform.position = Vector3.up * 5f;

        //장애물 종류에 따라 데미지 다르게 설정할 것
        newObstacle.GetComponent<ObstacleCollision>().SetDamage(10);
    }

    private void Update()
    {
        if (delay > 0) delay -= Time.deltaTime;
        else
        {
            delay = 1;
            Generate();
        }
    }
}
