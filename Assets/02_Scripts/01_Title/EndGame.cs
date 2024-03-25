//===============================================
//ゲーム終了処理
//三宅歩人
//===============================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] Text endText;      //テキスト

    // Start is called before the first frame update
    void Start()
    {
        //フォントサイズを64、色を黒に
        endText.color = Color.black;
        endText.fontSize = 64;
    }

    //マウスカーソルが乗った時
    public void OnMouseOver()
    {
        //フォントサイズを80、色を赤に
        endText.color = Color.red;
        endText.fontSize = 80;
    }

    //マウスカーソルが離れた時
    public void OnMouseExit()
    {
        //フォントサイズを64、色を黒に
        endText.color = Color.black;
        endText.fontSize = 64;
    }

    //ゲーム終了
    public void GameExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }
}
