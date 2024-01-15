using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePick : MonoBehaviour
{
    RaycastHit2D hit;
    [SerializeField] Handle handle;
    public Transform targetRotate;
    float TargetRotZ;
    public float overTargetValue = 0;
    private void Start()
    {
        ResetRot();
    }
    void ResetRot()
    {
        var overValue = Random.Range(0, overTargetValue);
        TargetRotZ = handle.transform.eulerAngles.z + (handle.flipRotate ? -overValue - 100 : overValue + 100);
        print($"{TargetRotZ} : ({handle.transform.eulerAngles.z} + ({overValue} +- 100)");
        targetRotate.eulerAngles = new Vector3(0,0,TargetRotZ);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(mousePos, Vector2.zero, 0.0f);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Handle"))
                {
                    if(handle.transform.eulerAngles.z >= targetRotate.eulerAngles.z - 15 
                    && handle.transform.eulerAngles.z <= targetRotate.eulerAngles.z + 15)
                    {
                        handle.flipRotate = !handle.flipRotate;
                        overTargetValue += 10;
                        overTargetValue = Mathf.Clamp(overTargetValue,0,100);
                        handle.Speed += 7;
                        ResetRot();
                    }
                }
            }
        }
    }
}
