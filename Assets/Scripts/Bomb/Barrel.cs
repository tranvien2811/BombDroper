using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public LayerMask layerMask;

    public float radiusExplosion;

    public float damage;

    public void timeExplosion()
    {
        StartCoroutine(OnExPlosion());        
    }

    public IEnumerator OnExPlosion()
    {
        yield return new WaitForSeconds(1f);
        Collider[] col = Physics.OverlapSphere(this.transform.position, radiusExplosion, layerMask);
        GameManager.Instance.Explosion(this.transform.position);
        for (int i = 0; i < col.Length; i++)
        {
            Enemy _en = col[i].GetComponent<Enemy>();
            if (_en != null)
            {
                _en.HeathEnemy -= damage;
            }
        }
        this.gameObject.SetActive(false);
    }
}
