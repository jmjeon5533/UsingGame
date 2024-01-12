using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloonClick : MonoBehaviour
{
    [SerializeField] private LayerMask bloonLayer;

    private bool isBloonCheck;

    private void Update()
    {
        Click();
    }

    private void Click()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0.0f, bloonLayer);

            if(hit.collider != null && hit.collider.CompareTag("Bloon"))
            {
                BloonCheck(hit);
            }
        }
    }

    private void BloonCheck(RaycastHit2D hit)
    {
        var bloons = hit.collider.gameObject.GetComponentInParent<BallonParent>().bloons;
        var clickBallon = hit.collider.gameObject.GetComponent<Bloon>();

        isBloonCheck = true;

        for (int index = 0; index < bloons.Count; index++)
        {
            var ballonCount = bloons[index].GetComponent<Bloon>().count;

            if(bloons.Count == 1)
            {
                break;
            }
            else if (clickBallon.count > ballonCount)
            {
                isBloonCheck = false;
                break;
            }
        }

        if(isBloonCheck)
        {
            // 리스트 제거하기
            Destroy(hit.collider.gameObject);
        }
        else
        {
            Debug.Log("작은 풍선이 아님");
        }
    }
}
