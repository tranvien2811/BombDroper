using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomClass
{ 
    public static int isBombDrag = 0;
    public static string AnimIdle = "idle";
    public static string AnimReLoadBullet = "reloadBullet";
    public static string AnimFight = "fight";
    public static string AnimVictory = "victory";
    public static string AnimRun = "run";
    public static string AnimDeath = "die";
}
   
[System.Serializable]
public class AirInfo
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

[System.Serializable]
public enum TYPE_BUY_AIR
{
    FREE,
    RANDOM,
    ADS,
    LEVEL,
}

[System.Serializable]
public enum TYPE_AIRCRAF
{
    BOOMER,
    APACHER,
    JETFIRE,    
    WARMACHINE,
    STINGRAY,
    BLACKOUT,
    SPACESHIP,
    SWAN,
    STARSCREAN,
    NIGHTFURY
}


[System.Serializable]
public class BombInfo
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
    public TYPE_BOMB typeBomb;
    public TYPE_BUY_BOMB typeBuyBomb;
    public int numBuyAds;
    public BOMB_MINI_DIRECTION_NUM miniBombType;
}

[System.Serializable]
public class BombSwap
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
    public TYPE_BOMB typeBomb;
    public TYPE_BUY_BOMB typeBuyBomb;
    public int numBuyAds;
    public BOMB_MINI_DIRECTION_NUM BombMini;

    public BombSwap(DataBomb bombInfo)
    {
        Name = bombInfo.Name;
        icon2DUi = bombInfo.icon2DUi;
        Describle = bombInfo.Describle;
        ID = bombInfo.ID;
        TimeCoundown = bombInfo.TimeCoundown;
        TimeExplosionRate = bombInfo.TimeExplosionRate;
        Range = bombInfo.Range;
        DamageBomb = bombInfo.DamageBomb;
        MiniBomb = bombInfo.MiniBomb;
        NumExplosion = bombInfo.NumExplosion;
        NumJumpBomb = bombInfo.NumJumpBomb;
        prefabsBombMini = bombInfo.prefabsBombMini;
        typeBuyBomb = bombInfo.typeBuyBomb;
        numBuyAds = bombInfo.numBuyAds;
        BombMini = bombInfo.miniBombType;
    }
}

[System.Serializable]
public enum BOMB_MINI_DIRECTION_NUM
{
    NONE,
    FOR,
    THREE
}

[System.Serializable]
public enum TYPE_BUY_BOMB
{
    FREE,
    RANDOM,
    ADS
}

[System.Serializable]
public enum TYPE_BOMB
{
    POP,
    BIGBOY,
    INEVITABLE,
    SAVAGE,
    AIRSTRIKE,
    BUBBLE
}



[System.Serializable]
public enum ENEMY_MOVE
{
    IDLE,
    MOVE,
    ATTRACK,
}

[System.Serializable]
public enum ENEMY_TYPE
{
    PISTON,
    AK47,
    SHOOTGUN,
    BOSS
}

