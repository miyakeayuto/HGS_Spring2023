using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public GameObject getItem;
    public GameObject clickedGameObject;//クリックされたゲームオブジェクトを代入する変数

    Vector2 targetPos;
    Vector3 startPos;
    public float speed = 9f;
    public bool isGetItem;
    public bool isMoveEnd;
    int time;

    public enum PLAYER_MODE
    {
        MOVE,  // 移動
        BUSY,  // 作業
        REST,  // 休憩
    }

    // プレイヤーのモード
    public PLAYER_MODE mode;

    // Start is called before the first frame update
    void Start()
    {
        isGetItem = false;
        mode = PLAYER_MODE.REST;
        targetPos = new Vector2();
        isMoveEnd = false;
        time = 1;
        startPos = this.transform.position;
    }

    private void Update()
    {
        if (GameManager.Instance.isGameStart == false || MiniGameManager.Instance.isMiniGameStart == true)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && mode != PLAYER_MODE.BUSY)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;
                Debug.Log(clickedGameObject.name);//ゲームオブジェクトの名前を出力
                Debug.Log(clickedGameObject.tag);//ゲームオブジェクトの名前を出力

                if (clickedGameObject.transform.tag == "Sapling")
                {// 苗木の場合
                    targetPos = clickedGameObject.transform.position;

                    if (targetPos.y > 0)
                    {
                        targetPos = new Vector2(targetPos.x, targetPos.y - 1.5f);
                    }
                    else
                    {
                        targetPos = new Vector2(targetPos.x, targetPos.y + 1.5f);
                    }

                    isMoveEnd = false;
                }
                else if(clickedGameObject.transform.tag == "Item")
                {// アイテムの場合
                    targetPos = clickedGameObject.transform.position;

                    targetPos = new Vector2(targetPos.x - 1.5f, targetPos.y);

                    isMoveEnd = false;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (targetPos == Vector2.zero || MiniGameManager.Instance.isMiniGameStart 
            || GameManager.Instance.isGameStart == false || GameManager.Instance.isGameEnd == true)
        {
            return;
        }

        if(isMoveEnd)
        {
            // %50で1秒間隔
            if (time % 50 == 0)
            {
                // スタート地点に戻る
                targetPos = startPos;
                isMoveEnd = false;
                time = 1;
            }

            time++; // カウントアップ
        }
        else
        {
            time = 1;
        }

        float dis = Vector3.Distance(targetPos, this.transform.position);

        if (dis <= 0f)
        {// 目的地にたどり着いた

            this.transform.position = targetPos;

            isMoveEnd = true;
        }
        else
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, targetPos, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(clickedGameObject == null || collision.tag != "Item")
        {
            return;
        }

        if (clickedGameObject.tag == "Item" && collision.tag == "Item")
        {
            if (getItem != null)
            {
                getItem.GetComponent<Item>().isPlayer = false;
            }

            isGetItem = true;
            clickedGameObject.GetComponent<Item>().isPlayer = true;
            getItem = clickedGameObject;
        }
    }
}
