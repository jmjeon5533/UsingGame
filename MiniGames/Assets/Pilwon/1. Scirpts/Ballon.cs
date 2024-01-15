using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour
{
    public int count;
    public int id;
    public GameObject paper;
    public Transform particlePos;
    public Canvas canvas;

    private void Awake()
    {
        canvas = GetComponentInChildren<Canvas>();
    }
}
