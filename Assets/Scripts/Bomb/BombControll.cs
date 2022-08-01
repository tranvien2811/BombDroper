using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BombControll : Bomb
{
    public BombSwap curentBombInfo;

    public bool isGround = false;

    public float timeExplosionRate;

    public GameObject prefabsMiniBomb;

    public List<Transform> posForDirection;

    public List<Transform> posThreeDirection;

   

    private void Start()
    {
        curentBombInfo = new BombSwap(dataBomb);
        timeExplosionRate = curentBombInfo.TimeExplosionRate;
        range = curentBombInfo.Range;
        dameBomb = curentBombInfo.DamageBomb;
    }

    public override void OnCollisionEnter(Collision coll)
    {
        base.OnCollisionEnter(coll);
    }    

    public override void callBackExPlosion()
    {
        base.callBackExPlosion();
        isGround = true;
        this.GetComponent<Rigidbody>().isKinematic = true;
        CreatMiniBomb(curentBombInfo.BombMini);
    }

    public void CreatMiniBomb(BOMB_MINI_DIRECTION_NUM typeDirection)
    {
        switch (typeDirection)
        {
            case BOMB_MINI_DIRECTION_NUM.NONE:
                break;
            case BOMB_MINI_DIRECTION_NUM.FOR:
                for (int i = 0; i < posForDirection.Count; i++)
                {
                    GameObject bullet = Instantiate(prefabsMiniBomb, transform.position, Quaternion.identity);
                    bullet.GetComponent<Rigidbody>().AddForce((posForDirection[i].position - transform.position) * 150f);
                    bullet.GetComponent<Collider>().enabled = true;
                }
                break;
            case BOMB_MINI_DIRECTION_NUM.THREE:
                for (int i = 0; i < posThreeDirection.Count; i++)
                {
                    GameObject bullet = Instantiate(prefabsMiniBomb, transform.position, Quaternion.identity);
                    bullet.GetComponent<Rigidbody>().AddForce((posThreeDirection[i].position - transform.position) * 150f);
                    bullet.GetComponent<Collider>().enabled = true;
                }
                break;
            default:
                break;
        }
        BombJump();
       
    }

    private void BombJump()
    {
        if (curentBombInfo.NumJumpBomb > 0)
        {
            curentBombInfo.NumJumpBomb--;
            isGround = false;
            Debug.Log("================================ 1");
            transform.DORotate(Vector3.right * 180f, 0.25f).OnComplete(()=> Debug.Log("================================"));
            transform.DOMoveY(1f, 0.25f).SetEase(Ease.InOutCirc)
                .OnComplete(() =>
                {
                    this.GetComponent<Rigidbody>().isKinematic = false;
                });
        }
        else
        {
            Destroy(this.gameObject, 0.15f);
        }
    }    

    
}
