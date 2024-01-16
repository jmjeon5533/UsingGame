using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    [Header("[ Spawn Pos ]")]
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    [Header("[ Spawn Time ]")]
    [SerializeField] private float spawnTime;

    private WaitForSeconds wSpawnTime;

    private void Awake()
    {
        wSpawnTime = new WaitForSeconds(spawnTime);
    }

    private void Start()
    {
        StartCoroutine(Co_Spawn());
    }

    private IEnumerator Co_Spawn()
    {
        while (true)
        {
            if (BallonGameManager.instance.isGameOver) continue;

            float posX = Random.Range(minX, maxX);
            float PosY = Random.Range(minY, maxY);
            Vector2 spawnPos = new Vector2(posX, PosY);

            GameObject clone = Instantiate(prefab, spawnPos, Quaternion.identity);
            clone.transform.SetParent(BallonGameManager.instance.ballonParent.transform);

            BallonGameManager.instance.spawnCount--;
            BallonGameManager.instance.fieldSpawnCount++;

            if (BallonGameManager.instance.spawnCount <= 0) break;
            yield return wSpawnTime;
        }
    }
}
