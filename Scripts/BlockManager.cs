using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public GameObject blockPrefab;
    public GameObject block;
    private float speed = 3f;
    private Vector3 moveDir;
    private float moveX;
    private Camera mainCam;
    private bool flag = true;
    public float cnt = 1;

    private void Start()
    {
        mainCam = Camera.main;
    }
    void Update()
    {
        Move();
        Block();
    }
    private void Block()
    {
        if(Time.timeScale==1)
            cnt += Input.GetButtonDown("Jump")?1:0;
        
        if (cnt==1 && !flag && Time.timeScale == 1 && block.GetComponent<Block>().flag)
        {
            block = Instantiate(blockPrefab);
            block.GetComponent<SpriteRenderer>().sortingOrder = 15;
            flag = true;
        }
        if (flag)
        {
            block.transform.position = transform.position;
            block.GetComponent<Rigidbody2D>().gravityScale = 0;
            if (Input.GetKeyDown(KeyCode.R))
            {
                block.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);
            }
            if (cnt==2)
            {
                block.GetComponent<Rigidbody2D>().gravityScale = 1;
                flag = false;
            }
        }
    }
    private void Move()
    {
        float lLim = mainCam.ViewportToWorldPoint(new Vector2(0,0)).x;
        float rLim = mainCam.ViewportToWorldPoint(new Vector2(1,1)).x;

        transform.position += moveDir*speed*Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,lLim, rLim), transform.position.y, 0);
        moveX = Input.GetAxisRaw("Horizontal");
        moveDir = new Vector3(moveX, 0, 0);
        
    }
}
