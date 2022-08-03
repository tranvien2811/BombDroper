using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Enemy : MonoBehaviour
{
    public float heathEnemy;
    public float timeRateFire;
    public float damage;
    
    public List<Transform> posMove;
    public float timeRateMoveNext;   
    public ENEMY_MOVE enemyMove;
    [HideInInspector]
    public ENEMY_MOVE fisrtEnemyMove;
    private int indexMove = 0;
    public float rangeAttrack;
    //[HideInInspector]
    public AstarAi target;

    public EnemyAnimationMessenger animationMessenger;

    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private ParticleSystem effectGun;    
   
    public float HeathEnemy
    {
        set 
        { 
            heathEnemy = value;
            this.gameObject.SetActive(heathEnemy <= 0 ? false : true);
        }
        get { return heathEnemy; }
    }

    public bool isFight;

    public ENEMY_MOVE ENEMYMOVE
    {
        set 
        { 
            enemyMove = value;
            switch (enemyMove)
            {
                case ENEMY_MOVE.IDLE:
                    animationMessenger.AnimIdle();
                    break;
                case ENEMY_MOVE.MOVE:
                    animationMessenger.AnimMove();
                    if (!DOTween.IsTweening(this.transform))
                    {
                        DOTween.Play(this.transform);
                    }
                    else
                    {
                        EnemyMove();
                    }
                    break;
                case ENEMY_MOVE.ATTRACK:
                    animationMessenger.AnimFight();
                    DOTween.Pause(this.transform);
                    break;
                default:
                    break;
            }
        }
        get { return enemyMove; }
    }
    public virtual void OnEnable()
    {
        isFight = true;
    }

    public virtual void Start()
    {
        fisrtEnemyMove = enemyMove;
        target = null;
        if (enemyMove == ENEMY_MOVE.MOVE)
        {
            animationMessenger.AnimMove();
            EnemyMove();
        }
    }

    public virtual void Update()
    {
        if (target != null)
        {
            Vector3 _dir = target.transform.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(_dir);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, 10f * Time.deltaTime).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
    }

    private void EnemyMove()
    {
        if (enemyMove == ENEMY_MOVE.MOVE)
        {
            if (indexMove == 0)
            {
                transform.DORotate(posMove[1].localEulerAngles, 0.15f);
                transform.DOMove(posMove[1].position, 5f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    indexMove = 1;
                    EnemyMove();
                });
            }
            else
            {
                transform.DORotate(posMove[0].localEulerAngles, 0.15f);
                transform.DOMove(posMove[0].position, 5f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    indexMove = 0;
                    EnemyMove();
                });
            }
        }
    }

    public void OnEffectShootGun()
    {
        if (target != null && target.Heath > 0)
        {
            target.Heath -= damage;
            if (target.Heath <= 0)
            {
                target = null;
            }
        }       
        effectGun.Simulate(0f);
        effectGun.Play();
    }

    public void UnActiveWeapon()
    {
       weapon.SetActive( false);        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, rangeAttrack);
    }
}
