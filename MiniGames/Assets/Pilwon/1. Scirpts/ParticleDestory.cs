using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestory : MonoBehaviour
{
    private void OnEnable()
    {
        Destroy(gameObject, 0.7f);
    }
}
