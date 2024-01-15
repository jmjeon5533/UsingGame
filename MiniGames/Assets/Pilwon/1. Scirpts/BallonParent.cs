using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallonParent : MonoBehaviour
{
    public List<Ballon> ballons = new List<Ballon>();
    [SerializeField] float speed;

    private void Start()
    {
        ballons.AddRange(GetComponentsInChildren<Ballon>());
        StartCoroutine(StartMove());
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!BallonPopGame.instance.isCurStageClear) return;
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    public void StageClearCheck()
    {
        if(ballons.Count <= 0) 
        {
            if (BallonPopGame.instance.stageLevel == BallonPopGame.instance.stages.Length - 1)
            {
                SceneManager.instance.NextGame();
            }
            else
            {
                BallonPopGame.instance.stageLevel++;
                BallonPopGame.instance.Init();
                BallonPopGame.instance.isCurStageClear = true;
                BallonPopGame.instance.isConveyorMove = true;
                SceneManager.instance.AddScore(500);
            }
        }
    }

    private void OnEnable()
    {
        BallonPopGame.instance.isGameStart = false;
        StartCoroutine(MoveWait());
    }

    private IEnumerator MoveWait()
    {
        yield return new WaitForSeconds(1.0f);
        transform.DOMove(new Vector3(0, -1.5f, 0), 2.0f);
        yield return new WaitForSeconds(1.0f);
        BallonPopGame.instance.isGameStart = true;
    }

    private IEnumerator StartMove()
    {
        yield return new WaitForSeconds(1.0f);
        BallonPopGame.instance.isConveyorMove = true;
        yield return new WaitForSeconds(2.0f);
        BallonPopGame.instance.isConveyorMove = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Stage"))
        {
            BallonPopGame.instance.isCurStageClear = false;
            BallonPopGame.instance.isConveyorMove = false;
            gameObject.SetActive(false);
        }
    }
}
