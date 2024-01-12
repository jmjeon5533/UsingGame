using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[System.Serializable]
public class CardInfo
{
    public Sprite sprite;
    public int index;
    public bool IsCorrect;
}
public class FindDupCard : Minigame
{
    [SerializeField] Transform canvas;
    [SerializeField] Camera cam;
    public Button tile;
    public Button[] tileButton;
    private Image[] tileImage;
    CardInfo[] tileInfo;
    public Vector2Int TileScale;
    public float tileDistance;
    private void Awake()
    {
        tileImage = new Image[TileScale.y * TileScale.x];
        tileInfo = new CardInfo[TileScale.y * TileScale.x];
    }
    private void Start()
    {
        for (int i = 0; i < tileImage.Length; i++)
        {
            var numX = i % TileScale.y;
            var numY = i / TileScale.x;
            tileButton[i].onClick.AddListener(() =>
            {
                print($"{numX} {numY}");
            });
            tileImage[i] = tileButton[i].transform.GetChild(0).GetComponent<Image>();
            tileImage[i].sprite = null;
        }
        CardShuffle();
    }
    void CardShuffle()
    {
        System.Random random = new System.Random();

        for (int i = 0; i < tileInfo.Length; i++)
        {
            int j = random.Next(i, 3);
            int curint = tileInfo[i].index;
            tileInfo[i].index = tileInfo[j].index;
            tileInfo[j].index = curint;
        }
        foreach(var t in tileInfo)
        {
            print(t.index);
        }
    }
}
