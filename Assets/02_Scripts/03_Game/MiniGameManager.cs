using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField] GameObject parent;
    [SerializeField] GameObject kusaPrefab;
    GameObject saplingObj;
    public bool isMiniGameStart;
    int num;

    // シングルトン用
    public static MiniGameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        isMiniGameStart = false;
    }

    public void SetMiniGame(GameObject target)
    {
        saplingObj = target;
        isMiniGameStart = true;
        num = Random.Range(4, 8);

        for (int i = 0; i < num; i++)
        {
            float x = (Random.Range(0, 121) - 60) * 0.1f;
            float y = (Random.Range(50, 300)) * 0.01f;
            Instantiate(kusaPrefab, new Vector3(x, y, -9f), Quaternion.identity, parent.transform);
        }

        parent.SetActive(true);
    }

    public void SubCounter()
    {
        num--;

        if (num <= 0)
        {// ミニゲームが終了
            saplingObj.GetComponent<Sapling>().ChangeState(true);
            parent.SetActive(false);
            saplingObj = null;
        }
    }

    public void EndMiniGame()
    {
        parent.SetActive(false);

        if(saplingObj != null)
        {
            saplingObj.GetComponent<Sapling>().ChangeState(false);
        }
    }
}
