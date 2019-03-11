using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Camera _camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float designWidth = 640;
        float designHeight = 1136;
        float designOrthographicSize = 5.68f;
        float designScale = designWidth / designHeight;
        float scaleRate = (float)Screen.width / (float)Screen.height;
        if(scaleRate < designScale)
        {
            float scale = scaleRate / designScale;
            _camera.orthographicSize = designOrthographicSize / scale;
        }
        else
        {
            _camera.orthographicSize = designOrthographicSize;
        }
	}
}
