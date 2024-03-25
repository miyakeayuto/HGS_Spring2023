using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public int highScore;
    public bool isGameEnd;
    public bool isGameStart;
    public bool isSpeedUP;

    // �V���O���g���p
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            highScore = 0;

            // �V�[���J�ڂ��Ă��j�����Ȃ��悤�ɂ���
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        score = 0;
        isSpeedUP = false;
    }

    private void Start()
    {
        isGameEnd = false;
        isGameStart = false;
    }
}