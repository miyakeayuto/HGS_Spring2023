//===============================================
//�Q�[���I������
//�O����l
//===============================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] Text endText;      //�e�L�X�g

    // Start is called before the first frame update
    void Start()
    {
        //�t�H���g�T�C�Y��64�A�F������
        endText.color = Color.black;
        endText.fontSize = 64;
    }

    //�}�E�X�J�[�\�����������
    public void OnMouseOver()
    {
        //�t�H���g�T�C�Y��80�A�F��Ԃ�
        endText.color = Color.red;
        endText.fontSize = 80;
    }

    //�}�E�X�J�[�\�������ꂽ��
    public void OnMouseExit()
    {
        //�t�H���g�T�C�Y��64�A�F������
        endText.color = Color.black;
        endText.fontSize = 64;
    }

    //�Q�[���I��
    public void GameExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
    }
}
