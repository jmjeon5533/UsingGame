using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hide : MonoBehaviour
{
    //public GameObject HideObject;
    //public GameObject ShowObject;
    //public GameObject target;
    public void Correct(float imgTime)
    {
        Debug.Log("�̾� ����");
        //SetTargetObjectActive(true);
        Debug.Log("�׽�Ʈ");

        StartCoroutine(ShowImgTime(imgTime));
        //SetTargetObjectActive(false);


    }

    public void wronganswer(float imgTime)
    {
        Debug.Log("���̰� ����");
        
        
        StartCoroutine(ShowImgTime(imgTime));
        
        
    }

    private IEnumerator ShowImgTime(float imgTime)
    {
        yield return new WaitForSeconds(imgTime);
        
    }
    //void SetTargetObjectActive(bool isActive)
    //{
        
        

        

    //    target.SetActive(isActive);

    //}



}
