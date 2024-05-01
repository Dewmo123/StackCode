using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public int sceneNum;
    public static SceneManagement instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void HardScene()
    {
        sceneNum = 1;
        SceneManager.LoadScene(sceneNum);
    }
}
