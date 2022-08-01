using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Air Data",menuName = "Creat air data")]
public class AirData : ScriptableObject
{
    public string Name;
    public Sprite Icon2DUi;
    [TextArea]
    public string Describe;
    public string ID;
    public float Heath;
    public float Speed;
    public float timeCoundown;
    public int numBuildAds;
    public int numLevelUnlock;
    public int numRandomUnlock;
    public TYPE_BUY_AIR typeBuild;
}
