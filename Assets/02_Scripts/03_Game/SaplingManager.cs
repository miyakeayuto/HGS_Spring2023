using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaplingManager : MonoBehaviour
{
    [SerializeField] List<GameObject> saplingList;
    [SerializeField] public List<GameObject> saplingPrefabList;
    [SerializeField] public List<GameObject> taskPrefabList;

    private void Start()
    {
        InvokeRepeating("SetTask", 0,3);
        InvokeRepeating("SetTask", 0,8);
    }

    private void SetTask()
    {
        while (true)
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
        }
    }
}
