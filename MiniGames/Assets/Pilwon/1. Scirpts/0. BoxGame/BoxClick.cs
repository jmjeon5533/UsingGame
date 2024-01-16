using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClick : MonoBehaviour
{
    [SerializeField] private LayerMask clickLayer;

    private RaycastHit2D hit;

    private bool isBoxCheck;

    private void Update()
    {
        Click();
    }

    private void Click()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(mousePos, Vector2.zero, 0.0f, clickLayer);

            if(hit.collider != null && hit.collider.CompareTag("Box"))
            {
                BallonCheck(hit);
            }
        }
    }

    private void BallonCheck(RaycastHit2D hit)
    {
        var ballonsParent = hit.collider.gameObject.GetComponentInParent<BoxParent>();
        var clickBallon = hit.collider.gameObject.GetComponent<Box>();

        isBoxCheck = true;

        for (int index = 0; index < ballonsParent.boxs.Count; index++)
        {
            var ballonCount = ballonsParent.boxs[index].GetComponent<Box>().count;

            if(ballonsParent.boxs.Count == 1)
            {
                break;
            }
            else if (clickBallon.count > ballonCount)
            {
                isBoxCheck = false;
                break;
            }
        }

        if(isBoxCheck) // Click Ballon < Other Ballon
        {
            ballonsParent.boxs.Remove(clickBallon);
            clickBallon.canvas.gameObject.SetActive(false);
            Instantiate(BoxPopGame.instance.particle, clickBallon.particlePos);
            clickBallon.paper.SetActive(true);

            // Stage Clear
            ballonsParent.StageClearCheck();
        }
        else // Click Ballon > Other Ballon
        {
            Debug.Log("¿€¿∫ «≥º±¿Ã æ∆¥‘");
        }
    }
}

