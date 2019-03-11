using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCtrl : MonoBehaviour {

    public float flySpeed = 1f;
    private Rigidbody2D _rigidbody2d;

	// Use this for initialization
	void Start () {
        _rigidbody2d = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            AudioManager.PlayAudioEffectA("Fly");
            _rigidbody2d.velocity = Vector2.up * flySpeed;
        }
	}
}
