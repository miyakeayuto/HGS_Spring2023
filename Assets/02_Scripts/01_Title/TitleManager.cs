using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.isGameEnd = false;
            GameManager.Instance.isGameStart = false;
            GameManager.Instance.score = 0;
        }
    }
}