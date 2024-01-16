using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallonGameManager : MonoBehaviour
{
    public static BallonGameManager instance { get; private set; }

    public GameObject particle;
    public bool isGameClear;
    public bool isGameOver;

    [Header("[ Spawn Var ]")]
    public int spawnCount; // 소환할 몬스터 수
    public int fieldSpawnCount; // 필드에 소환된 몬스터 수

    [Header("[ Spawn Parent ]")]
    public GameObject particleParent;
    public GameObject ballonParent;

    [Header("[ Click Count ]")]
    public int minCount;
    public int maxCount;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        GameClear();
    }

    private void GameClear()
    {
        if(spawnCount <= 0 && fieldSpawnCount <= 0)
        {
            isGameClear = true;
            SceneManager.instance.NextGame();
        }
    }

    public void GameOver()
    {
        if(isGameOver)
        {
            SceneManager.instance.NextGame();
        }
    }
}
