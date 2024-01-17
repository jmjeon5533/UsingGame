using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpManager : MonoBehaviour
{
    [SerializeField] GameObject[] hpImage;
    public int Hp = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hpupdate()
    {
        for (int i = 0; i < hpImage.Length; i++)
        {
            hpImage[i].SetActive(false);
        }
        for (int i = 0; i < Hp; i++)
        {
            hpImage[i].SetActive(true);
        }
    }
}
