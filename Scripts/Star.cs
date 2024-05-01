using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private Camera mainCam;
    private Vector2 xLimit;
    void Start()
    {
        mainCam = Camera.main;
        xLimit = mainCam.ViewportToWorldPoint(new Vector2(0, 0));
    }
    void Update()
    {
        if (transform.position.x < xLimit.x)
        {
            Destroy(gameObject);
        }
    }
}
