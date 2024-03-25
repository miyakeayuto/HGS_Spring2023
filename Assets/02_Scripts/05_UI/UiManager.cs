//===============================================
//UIマネージャー
//三宅歩人
//===============================================
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] Text timerText;                //タイマーのテキスト
    [SerializeField] float timerSeconds;            //タイマー（秒）
    [SerializeField] int timerMinutes;              //タイマー（分）
    [SerializeField] GameObject gameEndText;        //ゲーム終了テキスト

    // Start is called before the first frame update
    void Start()
    {
        //ゲーム終了テキストを非表示
        gameEndText.SetActive(false);
        //タイマー（分）の設定
        timerMinutes = 2;
        //タイマー（秒）を　分*60　で設定
        timerSeconds = timerMinutes * 60;
    }

    // Update is called once per frame
    void Update()
    {
        //カウントダウン
        timerSeconds -= Time.deltaTime;
        //インスタンスを生成
        var span = new TimeSpan(0, 0, (int)timerSeconds);
        //フォーマットする
        timerText.text = span.ToString(@"m\:ss");

        if(timerSeconds < 0)
        {
            timerSeconds = 0;

            //ゲーム終了テキストを表示
            gameEndText.SetActive(true);
        }
    }
}