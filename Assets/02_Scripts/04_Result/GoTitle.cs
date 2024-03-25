//===============================================
//�^�C�g����ʑJ�ڏ���
//�O����l
//===============================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoTitle : MonoBehaviour
{
    [SerializeField] Text goTitleText;          //�e�L�X�g

    // Start is called before the first frame update
    void Start()
    {
        //�t�H���g�T�C�Y��64�A�F������
        goTitleText.color = Color.black;
        goTitleText.fontSize = 64;
    }

    //�}�E�X�J�[�\�����������
    public void OnMouseOver()
    {
        //�t�H���g�T�C�Y��80�A�F��Ԃ�
        goTitleText.color = Color.red;
        goTitleText.fontSize = 80;
    }

    //�}�E�X�J�[�\�������ꂽ��
    public void OnMouseExit()
    {
        //�t�H���g�T�C�Y��64�A�F������
        goTitleText.color = Color.black;
        goTitleText.fontSize = 64;
    }

    public void GoTitleScene()
    {
        Initiate.Fade("01_Title", Color.black, 1.0f);
    }
}
