using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private float delay;

    private void Generate()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefab.Length);
        GameObject newObstacle = Instantiate(obstaclePrefab[obstacleIndex]);
        newObstacle.transform.position = new Vector2(Random.Range(-5.5f, 5.5f), 6);

        //��ֹ� ������ ���� ������ �ٸ��� ������ ��
        newObstacle.GetComponent<ObstacleCollision>().SetDamage((obstacleIndex+1) * 5);
    }

    private void Update()
    {
        if (delay > 0) delay -= Time.deltaTime;
        else
        {
            delay = 1.0f / GameManager.Instance.stageDifficulty;
            Debug.Log(1.0f / GameManager.Instance.stageDifficulty);
            Generate();
        }
    }
}
