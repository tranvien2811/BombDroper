using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarMachine : Air
{
    public Transform Fan;

    public float fanSpeed;

    private void Update()
    {
        Fan.Rotate(Vector3.forward, 2000f * Time.deltaTime);
    }
}
