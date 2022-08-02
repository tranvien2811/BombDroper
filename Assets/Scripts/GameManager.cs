using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public AirData airData;

    public GameObject exPlosion;

    public Bomb[] bombs;

    public AstarAi airs;

    public TouchControll touchControll;

    public Transform HitTarget;

    public Transform LastTarget;

    public GameObject Map;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        Instantiate(Map, Vector3.zero, Quaternion.identity);
    }

    public void Explosion(Vector3 pos)
    {
        Instantiate(exPlosion, pos + Vector3.up * 2f, Quaternion.identity);
    }   

}
