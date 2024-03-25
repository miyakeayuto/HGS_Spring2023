using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool isPlayer;
    Vector3 startPos;
    [SerializeField] GameObject player;
    public enum ITEM_NAME
    {
        Fertilizer,  // îÏóø
        Water,       // êÖ
    }

    public ITEM_NAME itemName;

    // Start is called before the first frame update
    void Start()
    {
        isPlayer = false;
        startPos = new Vector3();
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayer)
        {
            this.transform.position = new Vector3(player.transform.position.x,player.transform.position.y + 1f);
        }
        else
        {
            this.transform.position = startPos;
        }
    }
}
