using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class KeepOnLoad : MonoBehaviour {

    private KeepOnLoad kol;

    void Awake()
    {
        if (!kol)
        {
            DontDestroyOnLoad(gameObject);
            kol = this;
        } else if(kol != this)
        {
            Destroy(gameObject);
        }
    }
}

