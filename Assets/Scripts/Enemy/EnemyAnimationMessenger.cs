using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationMessenger : MonoBehaviour
{
   
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private Enemy enemy;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AnimMove();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            AnimReLoad();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            AnimIdle();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            AnimFight();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            AnimVictory();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            AnimDeath();
        }
    }

    public void AnimMove()
    {
        anim.SetBool(CustomClass.AnimIdle, false);
        anim.SetBool(CustomClass.AnimDeath, false);
        anim.SetBool(CustomClass.AnimFight, false);
        anim.SetBool(CustomClass.AnimRun, true);
        anim.SetBool(CustomClass.AnimVictory, false);
        anim.SetBool(CustomClass.AnimReLoadBullet, false);

    }

    public void AnimReLoad()
    {
        if (enemy.target != null)
        {
            anim.SetBool(CustomClass.AnimIdle, false);
            anim.SetBool(CustomClass.AnimDeath, false);
            anim.SetBool(CustomClass.AnimRun, false);
            anim.SetBool(CustomClass.AnimVictory, false);
            anim.SetBool(CustomClass.AnimReLoadBullet, true);
            anim.SetBool(CustomClass.AnimFight, false);
        }
        else
        {
            enemy.isFight = true;
        }
    }

    public void AnimIdle()
    {       
        anim.SetBool(CustomClass.AnimIdle, true);
        anim.SetBool(CustomClass.AnimDeath, false);
        anim.SetBool(CustomClass.AnimRun, false);
        anim.SetBool(CustomClass.AnimVictory, false);
        anim.SetBool(CustomClass.AnimReLoadBullet, false);
        anim.SetBool(CustomClass.AnimFight, false);
       
    }

    public void AnimIdleMessgenger()
    {
        enemy.isFight = true;
        enemy.ENEMYMOVE = ENEMY_MOVE.IDLE;
    }

    public void AnimFight()
    {
        anim.SetBool(CustomClass.AnimIdle, false);
        anim.SetBool(CustomClass.AnimDeath, false);
        anim.SetBool(CustomClass.AnimRun, false);
        anim.SetBool(CustomClass.AnimVictory, false);
        anim.SetBool(CustomClass.AnimReLoadBullet, false);
        anim.SetBool(CustomClass.AnimFight, true);        
    }

    public void AnimDeath()
    {
        anim.SetBool(CustomClass.AnimIdle, false);
        anim.SetBool(CustomClass.AnimDeath, true);
        anim.SetBool(CustomClass.AnimRun, false);
        anim.SetBool(CustomClass.AnimVictory, false);
        anim.SetBool(CustomClass.AnimReLoadBullet, false);
        anim.SetBool(CustomClass.AnimFight, false);
    }

    public void AnimVictory()
    {        
        anim.SetBool(CustomClass.AnimIdle, false);
        anim.SetBool(CustomClass.AnimDeath, false);
        anim.SetBool(CustomClass.AnimRun, false);
        anim.SetBool(CustomClass.AnimVictory, true);
        anim.SetBool(CustomClass.AnimReLoadBullet, false);
        anim.SetBool(CustomClass.AnimFight, false);
    }

    public void DesActiveWeapon()
    {
        enemy.UnActiveWeapon();
    }

    public void IsReLoadComplete()
    {
        enemy.isFight = true;
    }

    public void isFighting()
    {
        enemy.isFight = false;
    }

    public void OnFireEfect()
    {
        enemy.OnEffectShootGun();
    }
}
