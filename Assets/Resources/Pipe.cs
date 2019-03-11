using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

    public bool isUp = false;
    private float interval = 3f;
    private float curTime = 0;

    private void Update()
    {
        if(isUp && Physics2D.Raycast(transform.position,Vector2.down,10f,1 << 8) && curTime > interval)
        {
            GameMgr.instance.increaseScore();
            curTime = 0f;
        }
        curTime += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag == "Player")
        {
            GameMgr.instance.GameOver();
        }
    }
}
