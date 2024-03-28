using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapling : MonoBehaviour
{
    [SerializeField] GameObject ferPrefab;
    [SerializeField] GameObject canvas;

    GameObject myTask;
    GameObject parent;
    List<GameObject> saplingPrefabList;
    GameObject saplingObj;
    public bool isSetMyTask;
    public bool isDie;
    int time;
    public int mySetNum;

    /// <summary>
    /// タスクの種類
    /// </summary>
    public enum TASK_ID
    {
        Fertilizer, // 肥料
        Water,      // 水
        Kusa,       // 草刈り
    }

    public TASK_ID id;

    /// <summary>
    /// 成長具合のID
    /// </summary>
    enum STATE_ID
    {
        Planter = 0,   // プランターのみ
        TREE,       // 
        FLOWER,
        DIE = 0,
    }

    STATE_ID stateNum = STATE_ID.Planter;

    // Start is called before the first frame update
    void Start()
    {
        isSetMyTask = false;
        parent = this.transform.parent.gameObject;
        saplingPrefabList = parent.GetComponent<SaplingManager>().saplingPrefabList;
        stateNum = 0;
        time = 1;
        isDie = false;
    }

    void FixedUpdate()
    {
        if(isSetMyTask == false)
        {
            time = 1;
        }

        // %50で1秒間隔
        if (time % 500 == 0)
        {
            // タスクを消す＆木を枯れさせる
            ChangeState(false);
            DieTask();
        }

        time++; // カウントアップ
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isSetMyTask && collision.tag == "Player"
            && collision.GetComponent<Player>().clickedGameObject == this.gameObject)
        {// クリックされているのが自分自身の場合
            GameObject item = collision.GetComponent<Player>().getItem;

            if(id == TASK_ID.Water && item.GetComponent<Item>().itemName == Item.ITEM_NAME.Water)
            {// タスク：水
                ChangeState(true);
                DieTask();
            }
            else if(id == TASK_ID.Fertilizer && item.GetComponent<Item>().itemName == Item.ITEM_NAME.Fertilizer)
            {// タスク：肥料
                ChangeState(true);
                DieTask();

                Instantiate(ferPrefab, new Vector3(transform.localPosition.x + 0.7f, transform.localPosition.y + 0.5f, -2f),
                    Quaternion.Euler(0f,0f,130f));
            }
            else if (id == TASK_ID.Kusa)
            {// タスク：草刈り
                MiniGameManager.Instance.SetMiniGame(this.gameObject);
                DieTask();
            }
        }
    }

    public void SetTask(GameObject prefab, int num)
    {
        if (num == 0)
        {
            id = TASK_ID.Fertilizer;
        }
        else if(num == 1)
        {
            id = TASK_ID.Water;
        }
        else if(num == 2)
        {
            id = TASK_ID.Kusa;
        }

        Vector3 pos = canvas.transform.localPosition;

        switch (mySetNum)
        {
            case 0:
                myTask = Instantiate(prefab, new Vector3(pos.x - 626, pos.y + 364, 0f), Quaternion.identity, canvas.transform);
                break;
            case 1:
                myTask = Instantiate(prefab, new Vector3(pos.x - 85, pos.y + 364, 0f), Quaternion.identity, canvas.transform);
                break;
            case 2:
                myTask = Instantiate(prefab, new Vector3(pos.x + 456, pos.y + 364, 0f), Quaternion.identity, canvas.transform);
                break;
            case 3:
                myTask = Instantiate(prefab, new Vector3(pos.x - 626, pos.y - 348, 0f), Quaternion.identity, canvas.transform);
                break;
            case 4:
                myTask = Instantiate(prefab, new Vector3(pos.x - 85, pos.y - 348, 0f), Quaternion.identity, canvas.transform);
                break;
            case 5:
                myTask = Instantiate(prefab, new Vector3(pos.x + 456, pos.y - 348, 0f), Quaternion.identity, canvas.transform);
                break;
        }


        isSetMyTask = true;
    }

    public void DieTask()
    {
        Destroy(myTask);
        isSetMyTask = false;
    }

    public void ChangeState(bool isSuccess)
    {
        if(MiniGameManager.Instance.isMiniGameStart == true)
        {
            return;
        }

        if(saplingObj != null)
        {// 現在表示している木を破棄する
            Destroy(saplingObj);
            saplingObj = null;
        }

        if (isSuccess)
        {
            stateNum++;

            // 成長具合に見合った木を生成
            saplingObj = Instantiate(saplingPrefabList[(int)stateNum], new Vector3(transform.localPosition.x, transform.localPosition.y + 0.7f, -5f), Quaternion.identity, this.transform);

            if (stateNum == STATE_ID.FLOWER)
            {// 花が咲いた場合
                isDie = true;
                Invoke("DieSapling", 3f);

                // スコア加算する
                GameManager.Instance.score++;
            }
        }
        else if (stateNum != STATE_ID.Planter)
        {
            stateNum = STATE_ID.DIE;
            isDie = true;

            // 枯れ木を生成する
            saplingObj = Instantiate(saplingPrefabList[0], new Vector3(transform.localPosition.x, transform.localPosition.y + 0.7f, -5f), Quaternion.identity, this.transform);

            Invoke("DieSapling", 3f);
        }
    }

    private void DieSapling()
    {
        Destroy(saplingObj);
        stateNum = STATE_ID.Planter;
        isDie = false;
    }
}
