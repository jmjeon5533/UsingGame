using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClick : MonoBehaviour
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
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(mousePos, Vector2.zero, 0.0f, bloonLayer);

            if (hit.collider != null && hit.collider.CompareTag("Box"))
            {
                BloonCheck(hit);
            }
        }
    }

    private void BloonCheck(RaycastHit2D hit)
    {
        var ballonsParent = hit.collider.gameObject.GetComponentInParent<BoxParent>();
        var clickBallon = hit.collider.gameObject.GetComponent<Box>();

        isBloonCheck = true;

        for (int index = 0; index < ballonsParent.boxs.Count; index++)
        {
            var ballonCount = ballonsParent.boxs[index].GetComponent<Box>().count;

            if (ballonsParent.boxs.Count == 1)
            {
                break;
            }
            else if (clickBallon.count > ballonCount)
            {
                isBloonCheck = false;
                break;
            }
        }

        if (isBloonCheck) // Click Ballon < Other Ballon
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
            BoxPopGame.instance.stages[BoxPopGame.instance.stageLevel].timer -= 0.5f;
            CameraShake.ShakeCamera(0.2f, 0.09f);

        }
    }
}

