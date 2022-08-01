using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bomb : MonoBehaviour
{
    public float range;

    public float dameBomb;

    public Transform bombRender;

    public DataBomb dataBomb;

    public virtual void OnCollisionEnter(Collision coll)
    {
        if ((coll.gameObject.layer == LayerMask.NameToLayer("GROUND") || coll.gameObject.layer == LayerMask.NameToLayer("Enemy")))
        {
            this.GetComponent<Rigidbody>().isKinematic = true;
            GameManager.Instance.Explosion(coll.contacts[0].point);
            physicBombExplosion();
            callBackExPlosion();
        }
    }
    
    public virtual void callBackExPlosion()
    {

    }

    private void physicBombExplosion()
    {
        Collider[] cols = Physics.OverlapSphere(this.transform.position, range);
        foreach (var item in cols)
        {
            if (item.GetComponent<Enemy>() != null)
            {
                item.GetComponent<Enemy>().HeathEnemy -= dameBomb;
            }
            if (item.GetComponent<Building>() != null)
            {
                item.GetComponent<Building>().HeathBuilding -= dameBomb;
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, range);
    }
}
