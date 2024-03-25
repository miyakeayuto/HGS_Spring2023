using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ResultManager : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] Text highScore;
    [SerializeField] GameObject parentObj;

    // Start is called before the first frame update
    void Start()
    {
        score.text = GameManager.Instance.score.ToString();
        highScore.text = GameManager.Instance.highScore.ToString();

        parentObj.transform.DOLocalMove(Vector3.zero,0.5f);
    }
}