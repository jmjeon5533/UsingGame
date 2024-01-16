using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[System.Serializable]
public class TrashInfo
{
    public Sprite trashSprite;
    public TrashClick.TrashType trashType;
}
public class TrashClick : MonoBehaviour
{
    public enum TrashType
    {
        Normal,
        Paper,
        Can,
        Glass,
        Plastic
    }
    RaycastHit2D hit;

    public TrashInfo[] trashData;
    [SerializeField] Trash trash;
    [SerializeField] Image TimeSlider;
    [SerializeField] AudioClip successSFX, failSFX;
    [SerializeField] AudioClip bgm;
    SpriteRenderer trashImg;

    float Maxtime;
    float curtime;

    bool isMove = false;
    bool isEnd = false;

    private void Start()
    {
        trashImg = trash.GetComponent<SpriteRenderer>();
        ResetTrash();
        Maxtime = 10;
        curtime = Maxtime;
        SceneManager.instance.SetAudio(bgm,SceneManager.SoundState.BGM,true);
    }
    public void ResetTrash()
    {
        var rand = Random.Range(0, trashData.Length);
        trash.trashType = trashData[rand].trashType;
        trashImg.sprite = trashData[rand].trashSprite;
        trash.transform.position = new Vector2(0, -6);
        trash.transform.DOMoveY(-3.5f, 0.5f);
    }
    void ResetTimer()
    {
        Maxtime -= 0.35f;
        curtime = Maxtime;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(mousePos, Vector2.zero, 0.0f);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Trash"))
                {
                    if (!isMove) StartCoroutine(Move(hit.collider.transform.position));
                    var trashCan = hit.collider.GetComponent<Trashcan>();
                    trashCan.Move();
                    if (trashCan.recycleType == trash.trashType)
                    {
                        if (SceneManager.instance != null)
                        {
                            SceneManager.instance.AddScore(50);
                            SceneManager.instance.SetAudio(successSFX, SceneManager.SoundState.SFX, false);
                        }
                        ResetTimer();
                    }
                    else
                    {
                        print("실패");
                        curtime -= Maxtime / 2;
                        if (SceneManager.instance != null)
                        {
                            SceneManager.instance.SetAudio(failSFX, SceneManager.SoundState.SFX, false);
                        }

                    }
                }
            }
        }
        curtime -= Time.deltaTime;
        if (curtime <= 0 && !isEnd)
        {
            isEnd = true;
            SceneManager.instance.NextGame();
        }
        TimeSlider.fillAmount = curtime / Maxtime;
    }
    IEnumerator Move(Vector2 pos)
    {
        isMove = true;
        yield return trash.transform.DOMove(pos, 0.5f).SetEase(Ease.OutQuart).WaitForCompletion();
        isMove = false;
        ResetTrash();
    }
}
