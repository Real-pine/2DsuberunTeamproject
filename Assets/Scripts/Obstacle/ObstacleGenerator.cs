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
