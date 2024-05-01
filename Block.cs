using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Block : MonoBehaviour
{
    public bool flag = false;
    private Rigidbody2D rigid;
    private Camera mainCam;
    private GameObject blockManager;
    private SpriteRenderer render;
    void Start()
    {   
        float ranScale = Random.Range(0.5f, 1f);
        mainCam = Camera.main;
        rigid = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        blockManager = GameObject.Find("BlockManager");
        transform.localScale=new Vector2(ranScale, ranScale);
        transform.Rotate(0, 0, Random.Range(0, 360));
        ColorChan();
    }
    private void FixedUpdate()
    {
        FixPos();
    }
    private void ColorChan()
    {
        render.color = new Color(Random.value,Random.value, Random.value);
    }
    private void FixPos()
    {
        if (flag && rigid.velocity == new Vector2(0, 0))
        {
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!flag)
        {
            ScoreManager.instance.SetScore(ScoreManager.instance.GetScore() + 1);
            blockManager.GetComponent<BlockManager>().cnt = 0;
            flag = true;
        }
        if (transform.position.y >= mainCam.ViewportToWorldPoint(new Vector2(0f, 0.7f)).y)
        {
            mainCam.transform.position += new Vector3(0, 1, 0);
            blockManager.transform.position += Vector3.up;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (flag)
            ScoreManager.instance.SetScore(ScoreManager.instance.GetScore() - 1);
        blockManager.GetComponent<BlockManager>().cnt = 0;
        flag = true;
        
    }

}
