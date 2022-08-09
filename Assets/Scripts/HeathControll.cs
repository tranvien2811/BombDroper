using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathControll : MonoBehaviour
{
    public Image imgHeathBar;
 
    public void ShowHeath(float _Amount)
    {
        StartCoroutine(FadeDame(_Amount));
    }

    IEnumerator FadeDame(float _Amount)
    {
        imgHeathBar.fillAmount = _Amount;
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}
