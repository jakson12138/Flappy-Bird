using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour {

    public static GameMgr instance;
    public GameObject bird;
    private Vector2 vecOriginalPosition;
    public GameObject MainUI;
    private Rigidbody2D _rigidbody2D;

    private int score = 0;

    public int getScore()
    {
        return score;
    }

    public void increaseScore()
    {
        score++;
        Debug.Log(score);
    }

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        _rigidbody2D = bird.gameObject.GetComponent<Rigidbody2D>();
        vecOriginalPosition = _rigidbody2D.position;
    }
	
    public void GameStart()
    {
        score = 0;
        PipeMoving.instance.GameStart();

        bird.GetComponent<Rigidbody2D>().isKinematic = false;
        bird.GetComponent<Rigidbody2D>().position = vecOriginalPosition;
        bird.GetComponent<HeroCtrl>().enabled = true;
    }

    public void GameOver()
    {
        PipeMoving.instance.GameOver();

        bird.GetComponent<HeroCtrl>().enabled = false;
        bird.GetComponent<Rigidbody2D>().isKinematic = true;

        _rigidbody2D.position = vecOriginalPosition;
        _rigidbody2D.velocity = Vector2.zero;

        Transform btn = MainUI.transform.Find("play");
        btn.gameObject.SetActive(true);

        MainUI.transform.Find("GameOver").gameObject.SetActive(true);
    }

	// Update is called once per frame
	void Update () {
	}
}
