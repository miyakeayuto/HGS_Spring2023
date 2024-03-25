//===============================================
//�Q�[���J�n����
//�O����l
//===============================================
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GoGame : MonoBehaviour
{
    [SerializeField] Text startText;        //�e�L�X�g
    [SerializeField] AudioClip selectSE;    //�I��SE
    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //�t�H���g�T�C�Y��64�A�F������
        startText.color = Color.black;
        startText.fontSize = 64;
    }

    //�}�E�X�J�[�\�����������
    public void OnMouseOver()
    {
        //�t�H���g�T�C�Y��80�A�F��Ԃ�
        startText.color = Color.red;
        startText.fontSize = 80;
    }

    //�}�E�X�J�[�\�������ꂽ��
    public void OnMouseExit()
    {
        //�t�H���g�T�C�Y��64�A�F������
        startText.color = Color.black;
        startText.fontSize = 64;
    }

    public void GoGameScene()
    {
        audioSource.PlayOneShot(selectSE);
        Initiate.Fade("02_Game", Color.black, 1.0f);
    }
}
