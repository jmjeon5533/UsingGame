using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour
{
    public bool flipRotate = false;
    public float Speed;
    private void Update() {
        transform.Rotate(Vector3.forward * (flipRotate ? 1 : -1) * Speed * Time.deltaTime);
    }

}
