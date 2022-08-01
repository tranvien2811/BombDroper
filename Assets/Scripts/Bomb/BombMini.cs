

using UnityEngine;

public class BombMini : Bomb
{
    public override void OnCollisionEnter(Collision coll)
    {
        base.OnCollisionEnter(coll);
    }

    public override void callBackExPlosion()
    {
        base.callBackExPlosion();
        Destroy(gameObject,0.1f);
    }
}
