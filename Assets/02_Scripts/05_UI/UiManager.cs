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
    [SerializeField] GameObject timerTextObj;       //�^�C�}�[�e�L�X�g�̃I�u�W�F�N�g
    [SerializeField] Text timerText;                //�^�C�}�[�̃e�L�X�g
    [SerializeField] float timerSeconds;            //�^�C�}�[�i�b�j
    [SerializeField] int timerMinutes;              //�^�C�}�[�i���j
    [SerializeField] bool isEnd;                    //�J�E���g�_�E�����I��������ǂ���
    [SerializeField] GameObject gameEndText;        //�Q�[���I���e�L�X�g
    [SerializeField] GameObject startTimerTextObj;  //�Q�[���I���e�L�X�g�̃I�u�W�F�N�g
    [SerializeField] Text startTimerText;           //�Q�[���J�n�J�E���g�_�E���e�L�X�g
    [SerializeField] float startTimer;              //�Q�[���J�n�J�E���g�_�E��
    [SerializeField] int tutorialTimer;             //�`���[�g���A���^�C�}�[
    [SerializeField] GameObject tutorialImg;        //�`���[�g���A���̉摜
    [SerializeField] AudioClip countDownSE;         //�J�E���g�_�E��SE
    [SerializeField] AudioClip endSE;               //�Q�[���I��SE
    [SerializeField] AudioSource audioSource;
    [SerializeField] bool isPlay;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //�`���[�g���A���̉摜���\��
        timerTextObj.SetActive(false);
        //�P�b���ƂɊ֐����Ă�
        InvokeRepeating("Tutorial", 1.0f, 1.0f);
        //�Q�[���I���e�L�X�g���\��
        gameEndText.SetActive(false);
        //�^�C�}�[���\��
        timerTextObj.SetActive(false);
        //�J�E���g�_�E���^�C�}�[�̔�\��
        startTimerTextObj.SetActive(false);
        //�^�C�}�[�i���j�̐ݒ�
        timerMinutes = 2;
        //�^�C�}�[�i�b�j���@��*60�@�Őݒ�
        timerSeconds = timerMinutes * 60;
        //�P�b���ƂɊ֐����Ă�
        InvokeRepeating("CountDown", 2.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    Initiate.Fade("SampleScene", Color.black, 1.0f);
        //}
        if (tutorialTimer == 0)
        {
            if (isEnd)
            {
                timerTextObj.SetActive(true);
                //�J�E���g�_�E��
                timerSeconds -= Time.deltaTime;
                //�C���X�^���X�𐶐�
                var span = new TimeSpan(0, 0, (int)timerSeconds);
                //�t�H�[�}�b�g����
                timerText.text = span.ToString(@"m\:ss");

                if (timerSeconds < 0)
                {
                    timerSeconds = 0;

                    //�Đ�
                    audioSource.PlayOneShot(endSE);

                    //�Q�[���I���e�L�X�g��\��
                    gameEndText.SetActive(true);
                }
            }
        }
    }

    //�J�E���g�_�E������
    void CountDown()
    {
        if (tutorialTimer == 0)
        {
            startTimerTextObj.SetActive(true);
            --startTimer;
            startTimerText.text = startTimer.ToString();
            if (!isPlay)
            {
                //�Đ�
                audioSource.PlayOneShot(countDownSE);
                isPlay = true;
            }
            if (startTimer < 0)
            {
                startTimer = 0;
                isEnd = true;
                startTimerTextObj.SetActive(false);
                CancelInvoke();
            }
        }
    }

    void Tutorial()
    {
        tutorialImg.SetActive(true);

        --tutorialTimer;
        if (tutorialTimer < 0)
        {
            tutorialTimer = 0;
            tutorialImg.SetActive(false);
            CancelInvoke("Tutorial");
        }
    }
}