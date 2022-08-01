using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public abstract class Air : MonoBehaviour
{
    public AirData airData;
  
    public float heath;

    public Material mt;

    public Material Smokes;

    public float Heath
    {
        set
        {
            heath = value;
            this.gameObject.SetActive(heath <= 0 ? false : true);
        }
        get { return heath; }
    }

    public virtual void OnEnable()
    {
        heath = airData.Heath;
        DoColorSmoke();
    }

    public virtual void OnDisable()
    {
        if (Smokes == null)
        {
            return;
        }
        Smokes.color = Color.white;
        DOTween.Kill(Smokes);
    }

    public virtual void Start()
    {
       
    }

    private void DoColorSmoke()
    {
        if (Smokes == null)
        {
            return;
        }
        Smokes.DOColor(new Color(1f, 0f, 0f, 1f), 0.15f).SetLoops(-1, LoopType.Yoyo);
    }

    public void OnHitColor()
    {
        int indexRecall = 5;
        OnReCallColor(() =>
        {
            indexRecall--;
        });
    }

    private void OnReCallColor(Action _callBack)
    {
        mt.DOColor(Color.red, 0.1f).OnComplete(() =>
        {
            mt.DOColor(Color.red, 0.1f).OnComplete(() =>
            {
                _callBack?.Invoke();
            });
        });
    }
}
