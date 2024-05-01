using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HpManager : MonoBehaviour
{
    public static HpManager instance = null;
    public float maxHp;
    public float currentHp;
    public bool flag = false;
    public GameObject gameOver;
    public Slider HpSlider;
    private void Awake()
    {
        currentHp = maxHp;
        HpSlider.value = currentHp / maxHp;
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        if (currentHp == 0&&!flag)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0f;
            flag = true;
        }
    }
    public void SetHp(float value)
    {
        currentHp = value;
        HpSlider.value = currentHp / maxHp;
    }
    public float GetHp()
    {
        return currentHp;
    }
}
