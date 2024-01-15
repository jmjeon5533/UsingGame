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
        Debug.Log("이야 정답");
        //SetTargetObjectActive(true);
        Debug.Log("테스트");

        StartCoroutine(ShowImgTime(imgTime));
        //SetTargetObjectActive(false);


    }

    public void wronganswer(float imgTime)
    {
        Debug.Log("아이고 오답");
        
        
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
