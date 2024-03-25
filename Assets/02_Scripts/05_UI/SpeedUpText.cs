using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpeedUpText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalMove(Vector3.zero, 1f);
        transform.DOLocalMove(new Vector3(-1500f,0f,0f), 1f).SetDelay(1.5f).OnComplete(Die);
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
