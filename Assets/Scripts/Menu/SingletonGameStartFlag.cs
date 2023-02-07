using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonGameStartFlag : MonoBehaviour
{
    public static SingletonGameStartFlag Instance { get; private set; }
    public bool flag = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
