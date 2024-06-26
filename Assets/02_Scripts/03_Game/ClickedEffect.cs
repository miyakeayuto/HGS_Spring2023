//===============================================
//マウスクリック時のエフェクト処理
//三宅歩人
//===============================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicedEffect : MonoBehaviour
{
    [SerializeField] GameObject effectPrefab;       //エフェクトのプレハブ
    [SerializeField] float deleteTime = 1.0f;       //エフェクトが消えるまでの時間

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //マウスカーソルの位置を取得。
            var mousePosition = Input.mousePosition;
            mousePosition.z = 3f;
            GameObject clone = Instantiate(effectPrefab, Camera.main.ScreenToWorldPoint(mousePosition),
                Quaternion.identity);
            Destroy(clone, deleteTime);
        }
    }
}
