//===============================================
//タイトル画面遷移処理
//三宅歩人
//===============================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoTitle : MonoBehaviour
{
    [SerializeField] Text goTitleText;          //テキスト

    // Start is called before the first frame update
    void Start()
    {
        //フォントサイズを64、色を黒に
        goTitleText.color = Color.black;
        goTitleText.fontSize = 64;
    }

    //マウスカーソルが乗った時
    public void OnMouseOver()
    {
        //フォントサイズを80、色を赤に
        goTitleText.color = Color.red;
        goTitleText.fontSize = 80;
    }

    //マウスカーソルが離れた時
    public void OnMouseExit()
    {
        //フォントサイズを64、色を黒に
        goTitleText.color = Color.black;
        goTitleText.fontSize = 64;
    }

    public void GoTitleScene()
    {
        Initiate.Fade("01_Title", Color.black, 1.0f);
    }
}
