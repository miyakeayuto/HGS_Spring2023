using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kama : MonoBehaviour
{
    [SerializeField] GameObject minigameManager;

    // 位置座標
    private Vector3 position;
    // スクリーン座標をワールド座標に変換した位置座標
    private Vector3 screenToWorldPointPosition;

    void Update()
    {
        // Vector3でマウス位置座標を取得する
        position = Input.mousePosition;
        // Z軸修正
        position.z = 10f;
        // マウス位置座標をスクリーン座標からワールド座標に変換する
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        // ワールド座標に変換されたマウス座標を代入
        gameObject.transform.position = screenToWorldPointPosition;

        this.gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -9.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            minigameManager.GetComponent<MiniGameManager>().PlaySE();
            Destroy(collision.transform.gameObject);
            MiniGameManager.Instance.SubCounter();
        }
    }
}
