using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    private void Awake()
    {
        instance = this;

    }

    public void _Timer(float cd,Action action)
    {
        StartCoroutine(ITimer(cd,action));
    }

    IEnumerator ITimer(float cd,Action action)
    {
        while (cd > 0)
        {
            cd-=Time.deltaTime;
            yield return null;
        }
        action.Invoke();
    }

}
