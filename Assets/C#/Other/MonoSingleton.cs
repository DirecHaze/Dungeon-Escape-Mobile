using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T _program;
    public static T Program
    {
        get
        {
            if (_program == null)
                Debug.Log(typeof(T).ToString() + "Is null");
            return _program;
        }
    }
    private void Awake()
    {
        _program = this as T;
        init();
    }
    public virtual void init()
    {
    }
}
