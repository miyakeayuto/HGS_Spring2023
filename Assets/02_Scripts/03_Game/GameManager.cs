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

    // シングルトン用
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            highScore = 0;

            // シーン遷移しても破棄しないようにする
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