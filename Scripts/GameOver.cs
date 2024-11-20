using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        HpManager.instance.maxHp = 100;
        SceneManager.LoadScene(1);
    }
    public void Main()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
