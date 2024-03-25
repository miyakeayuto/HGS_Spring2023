using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaplingManager : MonoBehaviour
{
    [SerializeField] List<GameObject> saplingList;
    [SerializeField] public List<GameObject> saplingPrefabList;
    [SerializeField] public List<GameObject> taskPrefabList;
    [SerializeField] AudioClip speedUpSE;       //スピードアップSE
    [SerializeField] AudioSource audioSource;
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
            //再生
            audioSource.PlayOneShot(speedUpSE);

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
        if(GameManager.Instance.isGameEnd || GameManager.Instance.isGameStart == false)
        {
            return;
        }

        int cnt = 0;

        while (cnt < 6)
        {
            int rnd1 = Random.Range(0, saplingList.Count);

            if (saplingList[rnd1].GetComponent<Sapling>().isSetMyTask == false 
                && saplingList[rnd1].GetComponent<Sapling>().isDie == false)
            {
                saplingList[rnd1].GetComponent<Sapling>().isSetMyTask = true;

                // タスクを設定
                int rnd2 = Random.Range(0, taskPrefabList.Count);
                saplingList[rnd1].GetComponent<Sapling>().SetTask(taskPrefabList[rnd2],rnd2);

                Debug.Log("タスクnum:" + rnd2);

                break;
            }

            cnt++;
        }
    }
}
