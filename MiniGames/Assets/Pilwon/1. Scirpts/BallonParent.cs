using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonParent : MonoBehaviour
{
    public List<Ballon> ballons = new List<Ballon>();

    private void Start()
    {
        ballons.AddRange(GetComponentsInChildren<Ballon>());
    }

    public void StageClearCheck()
    {
        if(ballons.Count <= 0) 
        {
            gameObject.SetActive(false);

            if (BallonPopGame.instance.stageLevel == BallonPopGame.instance.stages.Length - 1)
            {
                SceneManager.instance.NextGame();
            }
            else
            {
                BallonPopGame.instance.stageLevel++;
                BallonPopGame.instance.Init();
            }
        }
    }
}
