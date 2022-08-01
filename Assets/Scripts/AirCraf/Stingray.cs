using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stingray : Air
{
    public Transform Fan;

    private void Update()
    {
        Fan.Rotate(Vector3.forward, 2000f * Time.deltaTime);
    }
}
