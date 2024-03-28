using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaplingManager : MonoBehaviour
{
    [SerializeField] List<GameObject> saplingList;
    [SerializeField] public List<GameObject> saplingPrefabList;
    [SerializeField] public List<GameObject> taskPrefabList;
    bool isCancel;
    bool isUpdate;

    private void Start()
    {
        InvokeRepeating("SetTask", 4,4);
        InvokeRepeating("SetTask", 4,9);
        isCancel = false;
        isUpdate = false;
    }

    private void Update()
    {
        if (GameManager.Instance.isSpeedUP && isUpdate == false)
        {
            isUpdate = true;

            InvokeRepeating("SetTask", 2, 2);
        }

        if(isCancel)
        {
            return;
        }

        if(GameManager.Instance.isGameEnd)
        {
            isCancel = true;
            CancelInvoke();
        }
    }

    private void SetTask()
    {
        if (GameManager.Instance.isGameEnd || GameManager.Instance.isGameStart == false || MiniGameManager.Instance.isMiniGameStart == true)
        {
            return;
        }

        int cnt = 0;

        while (cnt < 6)
        {
            if (MiniGameManager.Instance.isMiniGameStart == true)
            {
                return;
            }

            int rnd1 = Random.Range(0, saplingList.Count);

            if (saplingList[rnd1].GetComponent<Sapling>().isSetMyTask == false 
                && saplingList[rnd1].GetComponent<Sapling>().isDie == false)
            {
                saplingList[rnd1].GetComponent<Sapling>().isSetMyTask = true;

                // タスクを設定
                int rnd2 = Random.Range(1, 101);

                if(rnd2 <= 40)
                {
                    rnd2 = 0;
                }
                else if(rnd2 <= 80)
                {
                    rnd2 = 1;
                }
                else
                {
                    rnd2 = 2;
                }

                saplingList[rnd1].GetComponent<Sapling>().SetTask(taskPrefabList[rnd2],rnd2);

                Debug.Log("タスクnum:" + rnd2);

                break;
            }

            cnt++;
        }
    }
}
