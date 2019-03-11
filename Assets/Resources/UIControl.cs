using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {

    public GameObject PrepareUI;
    public GameObject MainUI;
    public GameObject HelpPanel;
    public GameObject bird;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Text score = MainUI.transform.Find("Score").GetComponent<Text>();
        int curScore = GameMgr.instance.getScore();
        score.text = "Score:" + curScore;
	}

    public void OnPreparePlayBtn()
    {
        PrepareUI.SetActive(false);
        MainUI.SetActive(true);
    }

    public void OnMainPlayBtn()
    {
        Button btn = MainUI.transform.Find("play").GetComponent<Button>();
        btn.gameObject.SetActive(false);
        MainUI.transform.Find("GameOver").gameObject.SetActive(false);

        GameMgr.instance.GameStart();
    }

    public void OnPrepareHomeBtn()
    {
        GameMgr.instance.GameOver();
        MainUI.SetActive(false);
        MainUI.transform.Find("GameOver").gameObject.SetActive(false);
        PrepareUI.SetActive(true);
    }

    public void OnPrepareQuitBtn()
    {
        Application.Quit();
    }

    public void OnHelpHomeBtn()
    {
        HelpPanel.SetActive(false);
        bird.SetActive(true);
    }

    public void OnPrepareHelpBtn()
    {
        HelpPanel.SetActive(true);
        bird.SetActive(false);
    }
}
