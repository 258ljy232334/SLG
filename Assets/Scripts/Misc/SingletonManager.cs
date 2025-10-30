using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//单例模式的基类,不含跨场景保存
public class SingletonManager<T> : MonoBehaviour where T : SingletonManager<T>
{
    protected static T _instance;
    public static T Instance => _instance;
    protected virtual void Awake()
    {
        if(_instance == null)
        {
            _instance = this as T;
        }
        else
        {
            Debug.LogWarning($"多余的{typeof(T).Name}单例");
            Destroy(gameObject);
            return;
        }
    }
}
