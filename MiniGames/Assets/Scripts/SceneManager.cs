using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using DG.Tweening;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance { get; private set; }
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public List<int> gameOrder = new List<int>();
    [SerializeField] Image FadeObj;
    public int Score;
    int curOrder = 0;

    public void GameStart()
    {
        curOrder = 0;
        for(int i = gameOrder.Count - 1; i > 0; i--)
        {
            int rnd = Random.Range(0,i);

            int temp = gameOrder[i];
            gameOrder[i] = gameOrder[rnd];
            gameOrder[rnd] = temp;
        }
        StartCoroutine(StartFade());
    }
    IEnumerator StartFade()
    {
        yield return FadeObj.DOColor(Color.black,0.5f).WaitForCompletion();
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameOrder[curOrder]);
        FadeObj.DOColor(Color.clear,0.5f).WaitForCompletion();
    }
    public void NextGame()
    {
        curOrder++;
        if(curOrder >= gameOrder.Count) 
        UnityEngine.SceneManagement.SceneManager.LoadScene("Result");

        else 
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameOrder[curOrder]);
    }
}
