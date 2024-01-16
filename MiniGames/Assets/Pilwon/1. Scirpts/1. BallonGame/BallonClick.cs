using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonClick : MonoBehaviour
{
    [SerializeField] private LayerMask clickLayer;

    private RaycastHit2D hit;

    private void Update()
    {
        if (BallonGameManager.instance.isGameOver) return;

        Click();
    }

    private void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(mousePos, Vector2.zero, 0.0f, clickLayer);

            if (hit.collider != null && hit.collider.CompareTag("Ballon"))
            {
                Ballon ballon = hit.collider.gameObject.GetComponent<Ballon>();
                StartCoroutine(Co_Size(ballon.gameObject));
                ballon.clickCount--;
            }
        }
    }

    private IEnumerator Co_Size(GameObject gameObject)
    {
        gameObject.transform.localScale *= 1.25f;
        yield return new WaitForSeconds(0.2f);
        if (gameObject != null) gameObject.transform.localScale /= 1.25f;
    }
}
