//===============================================
//�����o���������ԏ���
//�O����l
//===============================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] Image speechImg;       //�Q�[�W�{�̉摜���C���X�y�N�^�[����Z�b�g
    [SerializeField] float limitTime;         //��������
    
    // Start is called before the first frame update
    void Start()
    {
        limitTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //�J�E���g�A�b�v
        limitTime += Time.deltaTime / 10;
        //limitTime�ɔ����ĉ摜��h��Ԃ�
        speechImg.fillAmount = limitTime;
    }
}
