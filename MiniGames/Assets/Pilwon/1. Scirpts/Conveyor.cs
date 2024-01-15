using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    private Renderer conveyor;
    [SerializeField] float speed;

    private void Awake()
    {
        conveyor = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (!BallonPopGame.instance.isConveyorMove) return;

        conveyor.material.mainTextureOffset += new Vector2(-speed * Time.deltaTime, 0);
    }
}
