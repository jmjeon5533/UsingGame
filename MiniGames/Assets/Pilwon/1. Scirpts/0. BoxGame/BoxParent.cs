using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoxParent : MonoBehaviour
{   
    public List<Box> boxs = new List<Box>();
    [SerializeField] float speed;

    private void Start()
    {
        boxs.AddRange(GetComponentsInChildren<Box>());
        StartCoroutine(StartMove());
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!BoxPopGame.instance.isCurStageClear) return;
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    public void StageClearCheck()
    {
        if(boxs.Count <= 0) 
        {
            if (BoxPopGame.instance.stageLevel == BoxPopGame.instance.stages.Length - 1)
            {
                SceneManager.instance.NextGame();
                Debug.Log("Stage Clear");
            }
            else
            {
                BoxPopGame.instance.stageLevel++;
                BoxPopGame.instance.Init();
                BoxPopGame.instance.isCurStageClear = true;
                BoxPopGame.instance.isConveyorMove = true;
            }
        }
    }

    private void OnEnable()
    {
        BoxPopGame.instance.isGameStart = false;
        StartCoroutine(MoveWait());
    }

    private IEnumerator MoveWait()
    {
        yield return new WaitForSeconds(1.0f);
        transform.DOMove(new Vector3(0, -1.5f, 0), 2.0f);
        yield return new WaitForSeconds(1.0f);
        BoxPopGame.instance.isGameStart = true;
    }

    private IEnumerator StartMove()
    {
        yield return new WaitForSeconds(1.0f);
        BoxPopGame.instance.isConveyorMove = true;
        yield return new WaitForSeconds(2.0f);
        BoxPopGame.instance.isConveyorMove = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Stage"))
        {
            BoxPopGame.instance.isCurStageClear = false;
            BoxPopGame.instance.isConveyorMove = false;
            gameObject.SetActive(false);
        }
    }
}
