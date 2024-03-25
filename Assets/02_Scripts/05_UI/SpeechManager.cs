//===============================================
//吹き出し制限時間処理
//三宅歩人
//===============================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] Image speechImg;       //ゲージ本体画像をインスペクターからセット
    [SerializeField] float limitTime;         //制限時間
    
    // Start is called before the first frame update
    void Start()
    {
        limitTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //カウントアップ
        limitTime += Time.deltaTime / 10;
        //limitTimeに伴って画像を塗りつぶす
        speechImg.fillAmount = limitTime;
    }
}
