using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private float delay = 1f;

    private void Generate()
    {
        GameObject newObstacle = Instantiate(obstaclePrefab);
        newObstacle.transform.position = new Vector2(Random.Range(-5.0f, 5.0f), 5);
    }

    private void Update()
    {
        if (delay > 0) delay -= Time.deltaTime;
        else
        {
            delay = 1f;
            Generate();
        }
    }
}
