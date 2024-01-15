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

        // ������ Ȯ���ϴ� �ڷ�ƾ ����
        StartCoroutine(MoveObjectCoroutine());
    }

    
    
    IEnumerator MoveObjectCoroutine()
    {
        if (true) // Ȥ�� ���ϴ� �������� ����
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
        // Ư�� �̸��� ������Ʈ ã��
        GameObject targetObject = GameObject.Find("wjdekq");

        // ������Ʈ�� ã�����ٸ� SetActive ���� ����

        targetObject.SetActive(isActive);
                
    }
}
