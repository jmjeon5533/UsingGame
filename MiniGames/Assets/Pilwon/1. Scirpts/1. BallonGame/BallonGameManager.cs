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
    public int spawnCount;
    public int fieldSpawnCount; 

    [Header("[ VFX ]")]
    public AudioClip ClickVfx;
    public AudioClip PungVfx; // 폭발음

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
        GameOver();
    }

    private void GameClear()
    {
        if(spawnCount <= 0 && fieldSpawnCount <= 0 && !isGameClear)
        {
            isGameClear = true;
            SceneManager.instance.NextGame();
        }
    }

    public void GameOver()
    {
        if(isGameOver && !isGameClear)
        {
            isGameClear = true;
            SceneManager.instance.NextGame();
        }
    }
}
