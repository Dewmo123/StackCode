using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    private float currentTime=0f;
    private float createTime;
    private float locateX;
    private float locateY;

    private Camera mainCam;
    
    private Vector2 locate;
    
    public GameObject starPrefab;
    public GameObject starPool;

    private void Start()
    {
        createTime = Random.Range(0.5f, 1.5f);
        mainCam = Camera.main;
        locate = mainCam.ViewportToWorldPoint(new Vector2(locateX, locateY));
    }
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > createTime)
        {
            locateY = Random.Range(0.65f, 1f);
            locateX = Random.Range(0, 1f);
            GameObject star = Instantiate(starPrefab,starPool.gameObject.transform);
            star.transform.position = new Vector3(locate.x, locate.y, 0);
            locate = mainCam.ViewportToWorldPoint(new Vector2(locateX, locateY));
            createTime = Random.Range(0.5f, 1.5f);
            currentTime = 0;
        }
    }
}
