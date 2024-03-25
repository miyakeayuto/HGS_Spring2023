//===============================================
//ゲーム開始処理
//三宅歩人
//===============================================
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GoGame : MonoBehaviour
{
    [SerializeField] Text startText;        //テキスト

    // Start is called before the first frame update
    void Start()
    {
        //フォントサイズを64、色を黒に
        startText.color = Color.black;
        startText.fontSize = 64;
    }

    //マウスカーソルが乗った時
    public void OnMouseOver()
    {
        //フォントサイズを80、色を赤に
        startText.color = Color.red;
        startText.fontSize = 80;
    }

    //マウスカーソルが離れた時
    public void OnMouseExit()
    {
        //フォントサイズを64、色を黒に
        startText.color = Color.black;
        startText.fontSize = 64;
    }

    public void GoGameScene()
    {
        Initiate.Fade("02_Game", Color.black, 1.0f);
    }
}
