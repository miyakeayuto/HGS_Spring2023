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
    [SerializeField] AudioClip speedSE;             //スピードUPのSE
    [SerializeField] AudioClip endSE;               //ゲーム終了SE
    [SerializeField] AudioSource audioSource;
    [SerializeField] bool isPlay;
    [SerializeField] GameObject startText;          //テキスト
    [SerializeField] GameObject speedUpText1;
    [SerializeField] GameObject speedUpText2;
    GameObject sceneLoader;
    bool isSpeedUp1;
    bool isSpeedUp2;

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
        timerMinutes = 1;
        //タイマー（秒）を　分*60　で設定
        timerSeconds = timerMinutes * 60;
        //１秒ごとに関数を呼ぶ
        InvokeRepeating("CountDown", 2.0f, 1.0f);

        sceneLoader = GameObject.Find("SceneLoader");
        isSpeedUp1 = false;
        isSpeedUp2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isClicked == false)
        {
            isClicked = true;
            GameManager.Instance.isGameStart = true;
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

                if (timerSeconds < 0 && GameManager.Instance.isGameEnd == false)
                {
                    timerSeconds = 0;

                    //再生
                    audioSource.PlayOneShot(endSE);

                    //ゲーム終了テキストを表示
                    gameEndText.SetActive(true);

                    GameObject saplingParent = GameObject.Find("SaplingList");
                    saplingParent.SetActive(false);

                    sceneLoader.GetComponent<SceneLoader>().LoadResult();
;
                    GameManager.Instance.isGameEnd = true;
                    GameManager.Instance.isGameStart = false;
                }

                if (timerSeconds <= 40 && isSpeedUp1 == false)
                {// 残り時間が40秒 && 非アクティブの場合
                    speedUpText1.SetActive(true);
                    isSpeedUp1 = true;
                    //再生
                    audioSource.PlayOneShot(speedSE);
                }
                else if (timerSeconds <= 15 && isSpeedUp2 == false)
                {// 残り時間が15秒 && 非アクティブの場合
                    speedUpText2.SetActive(true);
                    isSpeedUp2 = true;
                    //再生
                    audioSource.PlayOneShot(speedSE);
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