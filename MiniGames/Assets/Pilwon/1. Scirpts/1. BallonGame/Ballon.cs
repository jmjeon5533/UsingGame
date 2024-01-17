using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ballon : MonoBehaviour
{
    public int clickCount;

    [Header("[ Level Up ]")]
    [SerializeField] private float levelUpTime;
    [SerializeField] private float maxLevelUpTime;

    [Header("[ Ballon Size ]")]
    [SerializeField] private BallonLevel ballonLevel;
    [SerializeField] private float[] scaleSize;

    private Canvas canvas;
    private TMP_Text text;

    private Rigidbody2D rigid;

    private void Awake()
    {
        canvas = GetComponentInChildren<Canvas>();
        text = GetComponentInChildren<TMP_Text>();
    }

    private void Start()
    {
        canvas.worldCamera = Camera.main;
        maxLevelUpTime = levelUpTime;
        text.text = clickCount.ToString();
    }

    private void Update()
    {
        if (BallonGameManager.instance.isGameOver) return;
        text.text = clickCount.ToString();

        LevelUp();
        Die();
    }

    private void Die()
    {
        if (clickCount <= 0)
        {
            GameObject clone = Instantiate(BallonGameManager.instance.particle, transform.position, Quaternion.identity);
            clone.transform.SetParent(BallonGameManager.instance.particleParent.transform);
            SceneManager.instance.AddScore(30);
            SceneManager.instance.SetAudio(BallonGameManager.instance.PungVfx, SceneManager.SoundState.SFX, false, 0.25f);

            BallonGameManager.instance.fieldSpawnCount--;
            Destroy(gameObject);
        }
    }

    #region Level Function
    private void LevelUp()
    {
        if (ballonLevel >= BallonLevel.Level_Max) return;

        levelUpTime -= Time.deltaTime;
        if (levelUpTime <= 0)
        {
            Level();
            levelUpTime = maxLevelUpTime;
        }
    }

    private void Level()
    {
        if (ballonLevel >= BallonLevel.Level_Max) return;

        ballonLevel++;
        transform.localScale = Vector3.one;
        switch (ballonLevel)
        {
            case BallonLevel.Level_1:
                transform.localScale *= scaleSize[(int)BallonLevel.Level_1];
                break;
            case BallonLevel.Level_2:
                transform.localScale *= scaleSize[(int)BallonLevel.Level_2];
                break;
            case BallonLevel.Level_3:
                transform.localScale *= scaleSize[(int)BallonLevel.Level_3];
                break;
            case BallonLevel.Level_4:
                transform.localScale *= scaleSize[(int)BallonLevel.Level_4];
                break;
            case BallonLevel.Level_5:
                transform.localScale *= scaleSize[(int)BallonLevel.Level_5];
                break;
            case BallonLevel.Level_Max:
                transform.localScale *= scaleSize[(int)BallonLevel.Level_Max];
                BallonGameManager.instance.isGameOver = true;
                break;
        }
    }
    #endregion

    private void OnEnable()
    {
        // Click Count Init
        clickCount = Random.Range(BallonGameManager.instance.minCount, BallonGameManager.instance.maxCount);
    }
}
