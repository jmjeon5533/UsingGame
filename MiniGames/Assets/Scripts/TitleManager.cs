using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public void GameStart() => SceneManager.instance.GameStart();
    [SerializeField] Image[] bgs;
    public float Speed;

    private void Update()
    {
        foreach(var b in bgs)
        {
            b.transform.Translate(Vector3.left * Speed * Time.deltaTime);
            if(b.transform.localPosition.x <= -1920) b.transform.position += Vector3.right * 1920 * bgs.Length;
        }
    }
}
