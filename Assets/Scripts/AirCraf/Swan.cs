using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swan : Air
{
    public Transform wing1;

    public Transform wing2;

    public Transform wing3;

    public Transform wing4;

    public override void Start()
    {
        base.Start();
    }

    public void Update()
    {
        wing1.Rotate(Vector3.forward, 2000f * Time.deltaTime);
        wing2.Rotate(Vector3.forward, 2000f * Time.deltaTime);
        wing3.Rotate(Vector3.back, 2000f * Time.deltaTime);
        wing4.Rotate(Vector3.back, 2000f * Time.deltaTime);
    }
}
