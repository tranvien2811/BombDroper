using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceBuilding : MonoBehaviour
{
    public float force;

    public Rigidbody rg;

    public void AddForceWhenExplosion(Vector3 direction)
    {
        rg.AddForce((this.transform.position - direction) * force);

    }
}
