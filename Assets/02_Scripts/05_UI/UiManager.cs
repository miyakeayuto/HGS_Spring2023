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
    [SerializeField] GameObject timerTextObj;       //タイマーテキストのオブジェクト
    [SerializeField] Text timerText;                //タイマーのテキスト
    [SerializeField] float timerSeconds;            //タイマー（秒）
    [SerializeField] int timerMinutes;              //タイマー（分）
    [SerializeField] bool isEnd;                    //カウントダウンが終わったかどうか
    [SerializeField] GameObject gameEndText;        //ゲーム終了テキスト
    [SerializeField] GameObject startTimerTextObj;  //ゲーム終了テキストのオブジェクト
    [SerializeField] Text startTimerText;           //ゲーム開始カウントダウンテキスト
    [SerializeField] float startTimer;              //ゲーム開始カウントダウン
    [SerializeField] bool isClicked;                //クリックしたか
    [SerializeField] GameObject tutorialImg;        //チュートリアルの画像
    [SerializeField] AudioClip countDownSE;         //カウントダウンSE
    [SerializeField] AudioClip endSE;               //ゲーム終了SE
    [SerializeField] AudioSource audioSource;
    [SerializeField] bool isPlay;
    [SerializeField] GameObject startText;          //テキスト

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //チュートリアルの画像を非表示
        timerTextObj.SetActive(false);
        //１秒ごとに関数を呼ぶ
        InvokeRepeating("Tutorial", 1.0f, 1.0f);
        //ゲーム終了テキストを非表示
        gameEndText.SetActive(false);
        //タイマーを非表示
        timerTextObj.SetActive(false);
        //カウントダウンタイマーの非表示
        startTimerTextObj.SetActive(false);
        //タイマー（分）の設定
        timerMinutes = 2;
        //タイマー（秒）を　分*60　で設定
        timerSeconds = timerMinutes * 60;
        //１秒ごとに関数を呼ぶ
        InvokeRepeating("CountDown", 2.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    Initiate.Fade("SampleScene", Color.black, 1.0f);
        //}
        if (Input.GetMouseButtonDown(0))
        {
            isClicked = true;
        }

        if (isClicked)
        {
            if (isEnd)
            {
                timerTextObj.SetActive(true);
                //カウントダウン
                timerSeconds -= Time.deltaTime;
                //インスタンスを生成
                var span = new TimeSpan(0, 0, (int)timerSeconds);
                //フォーマットする
                timerText.text = span.ToString(@"m\:ss");

                if (timerSeconds < 0)
                {
                    timerSeconds = 0;

                    //再生
                    audioSource.PlayOneShot(endSE);

                    //ゲーム終了テキストを表示
                    gameEndText.SetActive(true);
                }
            }
        }
    }

    //カウントダウン処理
    void CountDown()
    {
        if (isClicked)
        {
            startTimerTextObj.SetActive(true);
            --startTimer;
            startTimerText.text = startTimer.ToString();
            if (!isPlay)
            {
                //再生
                audioSource.PlayOneShot(countDownSE);
                isPlay = true;
            }
            if (startTimer < 0)
            {
                startTimer = 0;
                isEnd = true;
                startTimerTextObj.SetActive(false);
                CancelInvoke();
            }
        }
    }

    void Tutorial()
    {
        tutorialImg.SetActive(true);
        if (isClicked)
        {
            tutorialImg.SetActive(false);
            startText.SetActive(false);
        }
    }
}