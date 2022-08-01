using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BombData",menuName = "Creat Bomb Data")]
public class BombData : ScriptableObject
{
    public List<BombInfo> bombInfos;
}
