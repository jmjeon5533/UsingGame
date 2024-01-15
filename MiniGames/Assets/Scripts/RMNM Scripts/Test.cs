using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private bool condition = true;
    private Vector2 originalPosition;
    private float moveDuration = 3f;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;

        // 조건을 확인하는 코루틴 시작
        StartCoroutine(MoveObjectCoroutine());
    }

    
    
    IEnumerator MoveObjectCoroutine()
    {
        if (true) // 혹은 원하는 조건으로 변경
        {
            if (condition)
            {                
                MoveObjectDown();
                yield return new WaitForSeconds(moveDuration);
                MoveObjectUp();            
            }            
        }
    }

    void MoveObjectDown()
    {
        transform.position = new Vector2(transform.position.x, 500);
    }
    void MoveObjectUp()
    {
        
        transform.position = originalPosition;
    }
    public void SetTargetObjectActive(bool isActive)
    {
        // 특정 이름의 오브젝트 찾기
        GameObject targetObject = GameObject.Find("wjdekq");

        // 오브젝트가 찾아졌다면 SetActive 값을 변경

        targetObject.SetActive(isActive);
                
    }
}
