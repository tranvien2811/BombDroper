using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class TaskTest : MonoBehaviour
{
    private void Start()
    {
        RotateForSeconds(1f);
    }

    public async void RotateForSeconds(float duration)
    {
        var end = Time.time + duration;
        while (Time.time < end)
        {
            transform.Rotate(new Vector3(1f, 1f) * Time.deltaTime * 150f);
            await Task.Yield();
        }
    }
}
