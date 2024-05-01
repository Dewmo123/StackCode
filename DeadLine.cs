using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadLine : MonoBehaviour
{
    public GameObject stop;
    private int cnt = 0;
    private bool flag = false;
    private void Update()
    {
        cnt += Input.GetKeyDown(KeyCode.Escape) ? 1 : 0;
        Debug.Log(cnt);
        if (cnt == 1&&!HpManager.instance.flag&&!flag)
        {
            Time.timeScale = 0;
            flag = true;
            stop.gameObject.SetActive(true);
        }
        if (cnt == 2 && !HpManager.instance.flag)
        {
            Time.timeScale = 1;
            stop.gameObject.SetActive(false);
            flag = false;
            cnt = 0;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == 6)
        {
            HpManager.instance.SetHp(HpManager.instance.GetHp() - 20);
        }
    }
    
}
