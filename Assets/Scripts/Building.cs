using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField]
    private float heathBuilding;

    public float HeathBuilding
    {
        set 
        { 
            heathBuilding = value;
            this.gameObject.SetActive(heathBuilding <= 0 ? false : true);
        }
        get { return heathBuilding; }
    }

}
