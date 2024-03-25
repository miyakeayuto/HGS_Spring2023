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
    [SerializeField] Text startTimerText;           //�Q�[���J�n�J�E���g�_�E���e�L�X�g
    [SerializeField] float startTimer;                //�Q�[���J�n�J�E���g�_�E��

    [SerializeField] GameObject speedUpText;
    GameObject sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        //�Q�[���I���e�L�X�g���\��
        gameEndText.SetActive(false);
        //�^�C�}�[���\��
        timerTextObj.SetActive(false);
        //�^�C�}�[�i���j�̐ݒ�
        timerMinutes = 1;
        //�^�C�}�[�i�b�j���@��*60�@�Őݒ�
        timerSeconds = timerMinutes * 60;
        //�P�b���ƂɊ֐����Ă�
        InvokeRepeating("CountDown", 1.0f, 1.0f);

        sceneLoader = GameObject.Find("SceneLoader");
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    Initiate.Fade("SampleScene", Color.black, 1.0f);
        //}

        if (isEnd)
        {
            timerTextObj.SetActive(true);
            //�J�E���g�_�E��
            timerSeconds -= Time.deltaTime;
            //�C���X�^���X�𐶐�
            var span = new TimeSpan(0, 0, (int)timerSeconds);
            //�t�H�[�}�b�g����
            timerText.text = span.ToString(@"m\:ss");

            if(timerSeconds < 30 && GameManager.Instance.isSpeedUP == false)
            {// 30�b�ȉ��̏ꍇ
                // �Q�[���X�s�[�hUP
                GameManager.Instance.isSpeedUP = true;

                // �A�N�e�B�u������
                speedUpText.SetActive(true);
            }

            if (timerSeconds < 0 && GameManager.Instance.isGameEnd == false)
            {
                GameManager.Instance.isGameEnd = true;

                // �n�C�X�R�A���X�V
                if(GameManager.Instance.score > GameManager.Instance.highScore)
                {// �X�R�A���X�V����ꍇ
                    GameManager.Instance.highScore = GameManager.Instance.score;
                }

                timerSeconds = 0;

                //�Q�[���I���e�L�X�g��\��
                gameEndText.SetActive(true);

                // ���U���g�V�[����ǂݍ���
                sceneLoader.GetComponent<SceneLoader>().Invoke("LoadResult", 2f);
                sceneLoader.GetComponent<SceneLoader>().Invoke("HideUI", 2f);
            }
        }
    }

    //�J�E���g�_�E������
    void CountDown()
    {
        --startTimer;
        startTimerText.text = startTimer.ToString();
        if (startTimer < 0)
        {
            startTimer = 0;
            isEnd = true;
            Destroy(startTimerText);
            CancelInvoke();
        }

        if(startTimer <= 0)
        {
            GameManager.Instance.isGameStart = true;
        }
    }

    void HideUI()
    {
        //�Q�[���I���e�L�X�g���\��
        gameEndText.SetActive(true);
    }
}