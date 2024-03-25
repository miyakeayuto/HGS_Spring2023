//===============================================
//�}�E�X�N���b�N���̃G�t�F�N�g����
//�O����l
//===============================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicedEffect : MonoBehaviour
{
    [SerializeField] GameObject effectPrefab;       //�G�t�F�N�g�̃v���n�u
    [SerializeField] float deleteTime = 1.0f;       //�G�t�F�N�g��������܂ł̎���

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //�}�E�X�J�[�\���̈ʒu���擾�B
            var mousePosition = Input.mousePosition;
            mousePosition.z = 3f;
            GameObject clone = Instantiate(effectPrefab, Camera.main.ScreenToWorldPoint(mousePosition),
                Quaternion.identity);
            Destroy(clone, deleteTime);
        }
    }
}
