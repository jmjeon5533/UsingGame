using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region DataClass
[System.Serializable]
public class BloonData
{
    public GameObject bollonObj;
    public int bloonCount;
}

[System.Serializable]
public class Stage
{
    public string stageName;
    public GameObject stageObj;
    public int maxTimter;
    public int timer;

    [Space(10)] public List<BloonData> bollon = new List<BloonData>();
}
#endregion

public class BloonPopGame : MonoBehaviour
{
    public Stage[] stages;
    [SerializeField] private int stageIndex = 0;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        Stage curStage = stages[stageIndex];

        for (int index = 0; index < curStage.bollon.Count; index++)
        {
            Bloon bloon = curStage.bollon[index].bollonObj.GetComponent<Bloon>();
            bloon.count = curStage.bollon[index].bloonCount; // 풍선 크기 설정 
        }
    }

}

// 1스테이지 - 3개, 5초
// 2스테이지 - 5개, 4초
// 3스테이지 - 7개, 3초
