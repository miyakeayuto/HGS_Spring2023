using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene("04_UI", LoadSceneMode.Additive);
    }

    public void LoadResult()
    {
        SceneManager.LoadScene("03_Result", LoadSceneMode.Additive);
    }
}