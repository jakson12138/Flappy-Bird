using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoving : MonoBehaviour {

    public static PipeMoving instance;
    public float floCirclePosition = -13f;
    public float originalCircle = -13f;
    public float floMovingSpeed = 1f;
    public float offset = 15;
    public GameObject GoBroadcastMsg;
    private Vector2 vecOriginalPosition;
    private bool isStartGame = false;
    private string[] childs = { "columnPipe_1", "columnPipe_1 (1)", "columnPipe_1 (2)" };
    private int index = 0;

    private void Awake()
    {
        instance = this;
    }

    public void GameStart()
    {
        isStartGame = true;
    }

    public void GameOver()
    {
        isStartGame = false;
        ResetPosition();
        floCirclePosition = originalCircle;
        GoBroadcastMsg.BroadcastMessage("ResetPosition");
        index = 0;
    }

    private void ResetPosition()
    {
        this.gameObject.transform.position = vecOriginalPosition;
    }

    // Use this for initialization
    void Start () {
        vecOriginalPosition = this.gameObject.transform.position;
        GoBroadcastMsg.BroadcastMessage("GetNewPosition");
    }
	
	// Update is called once per frame
	void Update () {
        if (isStartGame)
        {
            if(this.gameObject.transform.position.x < floCirclePosition)
            {
                Transform child = this.transform.Find(nextName());
                Vector2 pos = child.position;
                pos.x += offset;
                child.position = pos;
                //this.gameObject.transform.position = vecOriginalPosition;
                floCirclePosition -= 5f;
                //GoBroadcastMsg.BroadcastMessage("GetNewPosition");
                child.GetComponent<ColumnPips>().GetNewPosition();
            }

            this.gameObject.transform.Translate(Vector2.left * Time.deltaTime * floMovingSpeed);
        }
	}

    string nextName()
    {
        string name = childs[index];
        index = (index + 1) % 3;
        return name;
    }
}
