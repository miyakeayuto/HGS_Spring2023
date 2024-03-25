using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaplingManager : MonoBehaviour
{
    [SerializeField] List<GameObject> saplingList;
    [SerializeField] public List<GameObject> taskPrefabList;

    private void Start()
    {
        InvokeRepeating("SetTask", 5,10);
    }

    private void SetTask()
    {
        Vector3 setPos = new Vector3();

        while (true)
        {
            int rnd1 = Random.Range(0, saplingList.Count);

            if (saplingList[rnd1].GetComponent<Sapling>().isSetMyTask == false)
            {
                saplingList[rnd1].GetComponent<Sapling>().isSetMyTask = true;

                setPos = new Vector3(saplingList[rnd1].transform.position.x + 1.3f, saplingList[rnd1].transform.position.y + 0.5f);

                // タスクを設定
                int rnd2 = Random.Range(0, taskPrefabList.Count);
                saplingList[rnd1].GetComponent<Sapling>().SetTask(taskPrefabList[rnd2], setPos,rnd2);

                Debug.Log("タスクnum:" + rnd2);

                break;
            }
        }
    }
}
