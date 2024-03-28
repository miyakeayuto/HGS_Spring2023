using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpeedUpText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalMove(Vector3.zero, 0.5f);
        transform.DOLocalMove(new Vector3(-1500f,0f,0f), 0.5f).SetDelay(1.25f).OnComplete(Die);
    }

    private void Die()
    {
        GameObject player = GameObject.Find("Player");
        player.GetComponent<Player>().speed += 3f;
        GameObject sapParent = GameObject.Find("SaplingList");
        sapParent.GetComponent<SaplingManager>().InvokeRepeating("SetTask", 0, 2.5f);
        Destroy(this.gameObject);
    }
}
