using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonClick : MonoBehaviour
{
    [SerializeField] private LayerMask bloonLayer;

    private RaycastHit2D hit;

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
            hit = Physics2D.Raycast(mousePos, Vector2.zero, 0.0f, bloonLayer);

            if(hit.collider != null && hit.collider.CompareTag("Ballon"))
            {
                BloonCheck(hit);
            }
        }
    }

    private void BloonCheck(RaycastHit2D hit)
    {
        var ballonsParent = hit.collider.gameObject.GetComponentInParent<BallonParent>();
        var clickBallon = hit.collider.gameObject.GetComponent<Ballon>();

        isBloonCheck = true;

        for (int index = 0; index < ballonsParent.ballons.Count; index++)
        {
            var ballonCount = ballonsParent.ballons[index].GetComponent<Ballon>().count;

            if(ballonsParent.ballons.Count == 1)
            {
                break;
            }
            else if (clickBallon.count > ballonCount)
            {
                isBloonCheck = false;
                break;
            }
        }

        if(isBloonCheck) // Click Ballon < Other Ballon
        {
            ballonsParent.ballons.Remove(clickBallon);
            ballonsParent.StageClearCheck();
            Destroy(hit.collider.gameObject);
        }
        else // Click Ballon > Other Ballon
        {
            Debug.Log("¿€¿∫ «≥º±¿Ã æ∆¥‘");
        }
    }
}

