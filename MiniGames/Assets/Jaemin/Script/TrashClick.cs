using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[System.Serializable]
public class TrashInfo
{
    public string name;
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
    }
    RaycastHit2D hit;

    public TrashInfo[] trashData;
    [SerializeField] Trash trash;
    SpriteRenderer trashImg;

    public int Maxtime;
    int curtime;

    bool isMove = false;

    private void Start()
    {
        trashImg = trash.GetComponent<SpriteRenderer>();
        ResetTrash();
    }
    public void ResetTrash()
    {
        var rand = Random.Range(0, trashData.Length);
        trash.trashType = trashData[rand].trashType;
        trashImg.sprite = trashData[rand].trashSprite;
        trash.transform.position = new Vector2(0, -6);
        trash.transform.DOMoveY(-3.5f, 0.5f);
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
                        SceneManager.instance.AddScore(100);
                    }
                    else
                    {
                        print("실패");
                        curtime -= 5;
                    }
                }
            }
        }
    }
    IEnumerator Move(Vector2 pos)
    {
        isMove = true;
        yield return trash.transform.DOMove(pos, 0.5f).SetEase(Ease.OutQuart).WaitForCompletion();
        isMove = false;
        ResetTrash();
    }
}
