using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieObj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Die", 2f);
    }

    private void Die()
    {
        Destroy(this.transform.gameObject);
    }
}
