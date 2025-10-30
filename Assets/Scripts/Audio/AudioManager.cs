using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonManager<AudioManager>
{
    protected override void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("多余的音频单例");
            Destroy(gameObject);
            return;
        }
    }
}
