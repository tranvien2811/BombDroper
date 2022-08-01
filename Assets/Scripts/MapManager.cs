using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;

    [SerializeField]
    private List<Enemy> enemies;

    public List<Enemy> Enemies
    {
        set { enemies = value; }
        get {return enemies; }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    public void checkRangerAttrack(Transform AirPos)
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            if (Vector3.Distance(Enemies[i].transform.position, AirPos.position) 
                <= Enemies[i].rangeAttrack)
            {
                if (Enemies[i].isFight && Enemies[i].enemyMove != ENEMY_MOVE.ATTRACK)
                {
                    Enemies[i].isFight = false;
                    Enemies[i].ENEMYMOVE = ENEMY_MOVE.ATTRACK;
                    Enemies[i].target = AirPos.GetComponent<AstarAi>();
                }               
                
            }
            else
            {
                Enemies[i].target = null;
                Enemies[i].ENEMYMOVE = Enemies[i].fisrtEnemyMove;
            }
        }
    }
}
