using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePick : MonoBehaviour
{
    RaycastHit2D hit;
    [SerializeField] Handle handle;
    public Transform targetRotate;
    float TargetRotZ;
    public float overTargetValue = 0;
    bool isOut;
    public int HP = 3;
    [SerializeField] GameObject[] hpImage;
    [SerializeField] AudioClip bgm;
    private void Start()
    {
        ResetRot();
        SceneManager.instance.SetAudio(bgm,SceneManager.SoundState.BGM,true);
    }
    void ResetRot()
    {
        var overValue = Random.Range(0, overTargetValue);
        TargetRotZ = handle.transform.eulerAngles.z + (handle.flipRotate ? -overValue - 100 : overValue + 100);
        print($"{TargetRotZ} : ({handle.transform.eulerAngles.z} + ({overValue} +- 100)");
        targetRotate.eulerAngles = new Vector3(0, 0, TargetRotZ);
    }
    void Update()
    {
        bool isRange = handle.transform.eulerAngles.z >= targetRotate.eulerAngles.z - 25
            && handle.transform.eulerAngles.z <= targetRotate.eulerAngles.z + 25;
        if (isRange)
        {
            isOut = true;
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                handle.flipRotate = !handle.flipRotate;
                overTargetValue += 10;
                overTargetValue = Mathf.Clamp(overTargetValue, 0, 100);
                handle.Speed += 5;
                ResetRot();
                isOut = false;
                SceneManager.instance.AddScore(50);
            }
        }
        else
        {
            if(isOut)
            {
                isOut = false;
                HP--;
                HPUpdate();
                if(HP <= 0) SceneManager.instance.NextGame();
            }
        }
    }
    void HPUpdate()
    {
        for(int i = 0; i < hpImage.Length; i++)
        {
            hpImage[i].SetActive(false);
        }
        for(int i = 0; i < HP; i++)
        {
            hpImage[i].SetActive(true);
        }
    }
}
