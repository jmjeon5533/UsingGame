using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public int count;
    public int id;
    public GameObject paper;
    public Transform particlePos;
    public Canvas canvas;
    public bool isClick;

    private void Awake()
    {
        canvas = GetComponentInChildren<Canvas>();
    }
}
