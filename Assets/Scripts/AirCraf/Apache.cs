using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Apache : Air
{
    public Transform wingMain;

    public Transform wingSide;

    public override void Start()
    {
        base.Start();        
    }

    public void Update()
    {
        wingMain.Rotate(Vector3.up, 2000f * Time.deltaTime);
        wingSide.Rotate(Vector3.left, 2000f * Time.deltaTime);
    }

}
