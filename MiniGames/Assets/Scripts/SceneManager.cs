using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using DG.Tweening;

[System.Serializable]
public class GameInfo
{
    public int sceneIndex;
    public string gameExplain;
    public Color panelColor;
}
public class SceneManager : MonoBehaviour
{
    public static SceneManager instance { get; private set; }
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public List<GameInfo> gameOrder = new List<GameInfo>();
    [SerializeField] Image fadeObj;
    [SerializeField] Image explainImg;
    [SerializeField] Text explainText;
    [SerializeField] Text scoreText;
    public int Score;
    int curOrder = 0;
    bool isFade;
    public void GameStart()
    {
        if(isFade) return;
        isFade = true;
        curOrder = 0;
        for (int i = gameOrder.Count - 1; i > 0; i--)
        {
            int rnd = Random.Range(0, i);

            GameInfo temp = gameOrder[i];
            gameOrder[i] = gameOrder[rnd];
            gameOrder[rnd] = temp;
        }
        StartCoroutine(StartFade());
    }
    IEnumerator StartFade()
    {
        // Fade In
        yield return fadeObj.DOFade(1f, 0.5f).WaitForCompletion();

        // Load Scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameOrder[curOrder].sceneIndex);

        // Set Time.timeScale to 0 (if needed)
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1f);

        // Fade Out
        yield return fadeObj.DOFade(0f, 0.5f).SetUpdate(true).WaitForCompletion();

        // Show explanation text
        explainText.text = gameOrder[curOrder].gameExplain;
        explainImg.color = gameOrder[curOrder].panelColor;
        scoreText.gameObject.SetActive(true);

        // Scale up explanation image
        yield return explainImg.rectTransform.DOSizeDelta(new Vector2(1920, 300), 0.5f).SetUpdate(true).WaitForCompletion();

        // Wait for a moment
        yield return new WaitForSecondsRealtime(1f);

        // Scale down explanation image
        yield return explainImg.rectTransform.DOSizeDelta(new Vector2(1920, 0), 0.5f).SetUpdate(true).WaitForCompletion();

        // Set Time.timeScale back to 1 (if needed)
        Time.timeScale = 1;
        isFade = false;
    }

    public void AddScore(int value)
    {
        Score += value;
        scoreText.text = "점수 : " + Score.ToString();
    }
    public void NextGame()
    {
        curOrder++;
        if (curOrder >= gameOrder.Count)
            UnityEngine.SceneManagement.SceneManager.LoadScene("Result");

        else
            StartCoroutine(StartFade());
    }
}
