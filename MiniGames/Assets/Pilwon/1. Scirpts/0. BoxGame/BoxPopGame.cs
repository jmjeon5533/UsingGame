using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

#region DataClass
[System.Serializable]
public class BallonData
{
    public GameObject ballonObj;
    public int ballonCount;

    [Space(5)]
    public TMP_Text text;
    public string textString;
}

[System.Serializable]
public class Stage
{
    public string stageName;
    public GameObject stageObj;
    public float maxTimter;
    public float timer;

    [Space(10)] public List<BallonData> ballon = new List<BallonData>();
}
#endregion

public class BoxPopGame : MonoBehaviour
{
    public static BoxPopGame instance { get; private set; }

    #region [ Var Region ] 
    public Stage[] stages;
    public int stageLevel = 0;
    public GameObject particle;

    [Header("[ VFX ]")]
    public AudioClip boxClickVfx;
    public AudioClip boxCancelVfx;

    [Header("[ Bool ]")]
    public bool isGameStart;
    public bool isCurStageClear;
    public bool isConveyorMove;
    private bool isStageClear;
    [Header("[ UI ]")]
    public Image timeSlider;
    #endregion

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (!isGameStart) return;

        if (stages[stageLevel].timer <= 0f)
        {
            stageLevel++;
            Init();
            isCurStageClear = true;
            isConveyorMove = true;

            CameraShake.ShakeCamera(0.2f, 0.09f);
            if (stageLevel == stages.Length - 1 && !isStageClear)
            {
                isStageClear = true;
                SceneManager.instance.NextGame();
            }
        }

        stages[stageLevel].timer -= Time.deltaTime;
        timeSlider.fillAmount = stages[stageLevel].timer / stages[stageLevel].maxTimter;

        // Game Over

    }

    public void Init()
    {
        Stage curStage = stages[stageLevel];

        curStage.stageObj.SetActive(true);
        for (int index = 0; index < curStage.ballon.Count; index++)
        {
            Box ballon = curStage.ballon[index].ballonObj.GetComponent<Box>();
            ballon.count = curStage.ballon[index].ballonCount;

            curStage.ballon[index].text = curStage.ballon[index].ballonObj.GetComponentInChildren<TMP_Text>();
            curStage.ballon[index].text.text = curStage.ballon[index].textString;
        }
    }

}

