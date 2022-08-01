using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataBomb", menuName = "CREAT_BOMB")]
public class DataBomb : ScriptableObject
{
    public string Name;
    public Sprite icon2DUi;
    [TextArea]
    public string Describle;
    public int ID;
    public float TimeCoundown;
    public float TimeExplosionRate;
    public float Range;
    public float DamageBomb;
    public GameObject MiniBomb;
    public int NumExplosion;
    public int NumJumpBomb;
    public GameObject prefabsBombMini;
    public TYPE_BUY_BOMB typeBuyBomb;
    public int numBuyAds;
    public BOMB_MINI_DIRECTION_NUM miniBombType;
}
