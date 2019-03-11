using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPips : MonoBehaviour {

    private Vector2 vecOriginalPostion;

	// Use this for initialization
	void Start () {
        vecOriginalPostion = this.gameObject.transform.position;
	}

    public void ResetPosition()
    {
        this.gameObject.transform.position = vecOriginalPostion;
    }
	
    private float GetRandomY()
    {
        float result = 0f;
        result = Random.Range(-3, 3);
        return result;
    }

    public void GetNewPosition()
    {
        Vector2 pos = this.gameObject.transform.position;
        this.gameObject.transform.position = new Vector2(pos.x, vecOriginalPostion.y + GetRandomY());
    }

    // Update is called once per frame
    void Update () {
		
	}
}
