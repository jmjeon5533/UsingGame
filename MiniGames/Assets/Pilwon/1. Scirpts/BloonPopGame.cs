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
            bloon.count = curStage.bollon[index].bloonCount; // ǳ�� ũ�� ���� 
        }
    }

}

// 1�������� - 3��, 5��
// 2�������� - 5��, 4��
// 3�������� - 7��, 3��
