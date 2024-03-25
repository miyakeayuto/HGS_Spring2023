using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    // �V���O���g���p
    public static BGMManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // �V�[���J�ڂ��Ă��j�����Ȃ��悤�ɂ���
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
