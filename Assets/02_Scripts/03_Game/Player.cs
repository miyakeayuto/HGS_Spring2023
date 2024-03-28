using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public GameObject getItem;
    public GameObject clickedGameObject;//�N���b�N���ꂽ�Q�[���I�u�W�F�N�g��������ϐ�

    Vector2 targetPos;
    Vector3 startPos;
    public float speed = 9f;
    public bool isGetItem;
    public bool isMoveEnd;
    int time;

    public enum PLAYER_MODE
    {
        MOVE,  // �ړ�
        BUSY,  // ���
        REST,  // �x�e
    }

    // �v���C���[�̃��[�h
    public PLAYER_MODE mode;

    // Start is called before the first frame update
    void Start()
    {
        isGetItem = false;
        mode = PLAYER_MODE.REST;
        targetPos = new Vector2();
        isMoveEnd = false;
        time = 1;
        startPos = this.transform.position;
    }

    private void Update()
    {
        if (GameManager.Instance.isGameStart == false || MiniGameManager.Instance.isMiniGameStart == true)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && mode != PLAYER_MODE.BUSY)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;
                Debug.Log(clickedGameObject.name);//�Q�[���I�u�W�F�N�g�̖��O���o��
                Debug.Log(clickedGameObject.tag);//�Q�[���I�u�W�F�N�g�̖��O���o��

                if (clickedGameObject.transform.tag == "Sapling")
                {// �c�؂̏ꍇ
                    targetPos = clickedGameObject.transform.position;

                    if (targetPos.y > 0)
                    {
                        targetPos = new Vector2(targetPos.x, targetPos.y - 1.5f);
                    }
                    else
                    {
                        targetPos = new Vector2(targetPos.x, targetPos.y + 1.5f);
                    }

                    isMoveEnd = false;
                }
                else if(clickedGameObject.transform.tag == "Item")
                {// �A�C�e���̏ꍇ
                    targetPos = clickedGameObject.transform.position;

                    targetPos = new Vector2(targetPos.x - 1.5f, targetPos.y);

                    isMoveEnd = false;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (targetPos == Vector2.zero || MiniGameManager.Instance.isMiniGameStart 
            || GameManager.Instance.isGameStart == false || GameManager.Instance.isGameEnd == true)
        {
            return;
        }

        if(isMoveEnd)
        {
            // %50��1�b�Ԋu
            if (time % 50 == 0)
            {
                // �X�^�[�g�n�_�ɖ߂�
                targetPos = startPos;
                isMoveEnd = false;
                time = 1;
            }

            time++; // �J�E���g�A�b�v
        }
        else
        {
            time = 1;
        }

        float dis = Vector3.Distance(targetPos, this.transform.position);

        if (dis <= 0f)
        {// �ړI�n�ɂ��ǂ蒅����

            this.transform.position = targetPos;

            isMoveEnd = true;
        }
        else
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, targetPos, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(clickedGameObject == null || collision.tag != "Item")
        {
            return;
        }

        if (clickedGameObject.tag == "Item" && collision.tag == "Item")
        {
            if (getItem != null)
            {
                getItem.GetComponent<Item>().isPlayer = false;
            }

            isGetItem = true;
            clickedGameObject.GetComponent<Item>().isPlayer = true;
            getItem = clickedGameObject;
        }
    }
}
