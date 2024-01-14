using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Trashcan : MonoBehaviour
{
    public TrashClick.TrashType recycleType;
    bool ismove;

    public void Move()
    {
        if (!ismove) StartCoroutine(ScaleEvent());
    }
    IEnumerator ScaleEvent()
    {
        ismove = true;
        yield return transform.DOScale(Vector3.one * 0.7f, 0.1f).WaitForCompletion();
        yield return transform.DOScale(Vector3.one * 1.3f, 0.1f).WaitForCompletion();
        ismove = false;
        yield return transform.DOScale(Vector3.one * 1f, 0.1f).WaitForCompletion();
    }
}
