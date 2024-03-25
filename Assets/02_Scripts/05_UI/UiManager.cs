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
    [SerializeField] Text startTimerText;           //ゲーム開始カウントダウンテキスト
    [SerializeField] float startTimer;                //ゲーム開始カウントダウン

    [SerializeField] GameObject speedUpText;
    GameObject sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        //ゲーム終了テキストを非表示
        gameEndText.SetActive(false);
        //タイマーを非表示
        timerTextObj.SetActive(false);
        //タイマー（分）の設定
        timerMinutes = 1;
        //タイマー（秒）を　分*60　で設定
        timerSeconds = timerMinutes * 60;
        //１秒ごとに関数を呼ぶ
        InvokeRepeating("CountDown", 1.0f, 1.0f);

        sceneLoader = GameObject.Find("SceneLoader");
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    Initiate.Fade("SampleScene", Color.black, 1.0f);
        //}

        if (isEnd)
        {
            timerTextObj.SetActive(true);
            //カウントダウン
            timerSeconds -= Time.deltaTime;
            //インスタンスを生成
            var span = new TimeSpan(0, 0, (int)timerSeconds);
            //フォーマットする
            timerText.text = span.ToString(@"m\:ss");

            if(timerSeconds < 30 && GameManager.Instance.isSpeedUP == false)
            {// 30秒以下の場合
                // ゲームスピードUP
                GameManager.Instance.isSpeedUP = true;

                // アクティブ化する
                speedUpText.SetActive(true);
            }

            if (timerSeconds < 0 && GameManager.Instance.isGameEnd == false)
            {
                GameManager.Instance.isGameEnd = true;

                // ハイスコアを更新
                if(GameManager.Instance.score > GameManager.Instance.highScore)
                {// スコアを更新する場合
                    GameManager.Instance.highScore = GameManager.Instance.score;
                }

                timerSeconds = 0;

                //ゲーム終了テキストを表示
                gameEndText.SetActive(true);

                // リザルトシーンを読み込む
                sceneLoader.GetComponent<SceneLoader>().Invoke("LoadResult", 2f);
                sceneLoader.GetComponent<SceneLoader>().Invoke("HideUI", 2f);
            }
        }
    }

    //カウントダウン処理
    void CountDown()
    {
        --startTimer;
        startTimerText.text = startTimer.ToString();
        if (startTimer < 0)
        {
            startTimer = 0;
            isEnd = true;
            Destroy(startTimerText);
            CancelInvoke();
        }

        if(startTimer <= 0)
        {
            GameManager.Instance.isGameStart = true;
        }
    }

    void HideUI()
    {
        //ゲーム終了テキストを非表示
        gameEndText.SetActive(true);
    }
}