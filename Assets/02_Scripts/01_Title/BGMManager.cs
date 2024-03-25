using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    // シングルトン用
    public static BGMManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // シーン遷移しても破棄しないようにする
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
