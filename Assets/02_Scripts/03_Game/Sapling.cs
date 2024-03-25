using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapling : MonoBehaviour
{
    GameObject myTask;
    public bool isSetMyTask;

    public enum TASK_ID
    {
        Fertilizer, // 肥料
        Water,      // 水
    }

    public TASK_ID id;

    // Start is called before the first frame update
    void Start()
    {
        isSetMyTask = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isSetMyTask && collision.tag == "Player")
        {
            GameObject item = collision.GetComponent<Player>().getItem;

            if(id == TASK_ID.Water && item.GetComponent<Item>().itemName == Item.ITEM_NAME.Water)
            {// タスク：水
                DieTask();
            }
            else if(id == TASK_ID.Fertilizer && item.GetComponent<Item>().itemName == Item.ITEM_NAME.Fertilizer)
            {// タスク：肥料
                DieTask();
            }
        }
    }

    public void SetTask(GameObject prefab,Vector3 pos,int num)
    {
        if(num == 0)
        {
            id = TASK_ID.Fertilizer;
        }
        else
        {
            id = TASK_ID.Water;
        }

        myTask = Instantiate(prefab, pos, Quaternion.identity,this.transform);
        isSetMyTask = true;
    }

    public void DieTask()
    {
        Destroy(myTask);
        isSetMyTask = false;
    }
}
