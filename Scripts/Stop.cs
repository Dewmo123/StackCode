using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Stop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        HpManager.instance.maxHp = 100;
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Main()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
