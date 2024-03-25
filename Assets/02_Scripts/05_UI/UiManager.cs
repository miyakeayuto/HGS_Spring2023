//===============================================
//UI�}�l�[�W���[
//�O����l
//===============================================
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] Text timerText;                //�^�C�}�[�̃e�L�X�g
    [SerializeField] float timerSeconds;            //�^�C�}�[�i�b�j
    [SerializeField] int timerMinutes;              //�^�C�}�[�i���j
    [SerializeField] GameObject gameEndText;        //�Q�[���I���e�L�X�g

    // Start is called before the first frame update
    void Start()
    {
        //�Q�[���I���e�L�X�g���\��
        gameEndText.SetActive(false);
        //�^�C�}�[�i���j�̐ݒ�
        timerMinutes = 2;
        //�^�C�}�[�i�b�j���@��*60�@�Őݒ�
        timerSeconds = timerMinutes * 60;
    }

    // Update is called once per frame
    void Update()
    {
        //�J�E���g�_�E��
        timerSeconds -= Time.deltaTime;
        //�C���X�^���X�𐶐�
        var span = new TimeSpan(0, 0, (int)timerSeconds);
        //�t�H�[�}�b�g����
        timerText.text = span.ToString(@"m\:ss");

        if(timerSeconds < 0)
        {
            timerSeconds = 0;

            //�Q�[���I���e�L�X�g��\��
            gameEndText.SetActive(true);
        }
    }
}