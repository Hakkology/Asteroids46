using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TekilYonetici<T> : MonoBehaviour where T : Component 
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this as T;
        }
    }
}
