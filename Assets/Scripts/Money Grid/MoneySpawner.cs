using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    public GameObject obj;
    public MoneyGrid mg;
    public float SpawnRate = 0.5f;

    private void Start()
    {

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        int i = 0;
        while (true)
        {
            var o = Instantiate(obj, mg.Next(i%6) , Quaternion.identity);
            o.transform.Rotate(-95,0,0);
            i++;
            yield return new WaitForSeconds(1 / SpawnRate);
        }
    }
}
