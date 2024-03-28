using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kama : MonoBehaviour
{
    [SerializeField] GameObject minigameManager;

    // �ʒu���W
    private Vector3 position;
    // �X�N���[�����W�����[���h���W�ɕϊ������ʒu���W
    private Vector3 screenToWorldPointPosition;

    void Update()
    {
        // Vector3�Ń}�E�X�ʒu���W���擾����
        position = Input.mousePosition;
        // Z���C��
        position.z = 10f;
        // �}�E�X�ʒu���W���X�N���[�����W���烏�[���h���W�ɕϊ�����
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        // ���[���h���W�ɕϊ����ꂽ�}�E�X���W����
        gameObject.transform.position = screenToWorldPointPosition;

        this.gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -9.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            minigameManager.GetComponent<MiniGameManager>().PlaySE();
            Destroy(collision.transform.gameObject);
            MiniGameManager.Instance.SubCounter();
        }
    }
}
