using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField]
    private float heathBuilding;

    private float MaxHeath;

    [SerializeField]
    private HeathControll heathControll;

    public float HeathBuilding
    {
        set 
        { 
            heathBuilding = value;
            bool check = heathBuilding <= 0 ? false : true;
            heathControll.gameObject.SetActive(check);
            heathControll.ShowHeath(heathBuilding / MaxHeath);
            this.gameObject.SetActive(check);
        }
        get { return heathBuilding; }
    }

    private void Start()
    {
        MaxHeath = heathBuilding;
    }
}
