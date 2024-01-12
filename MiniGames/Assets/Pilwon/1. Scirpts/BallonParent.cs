using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonParent : MonoBehaviour
{
    public List<Bloon> bloons = new List<Bloon>();

    private void Start()
    {
        bloons.AddRange(GetComponentsInChildren<Bloon>());
    }
}
