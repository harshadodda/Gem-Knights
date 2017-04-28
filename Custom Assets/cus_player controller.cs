using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cus_playercontroller : MonoBehaviour {

    public Animator player;
    public float speed = 10.0F;
    public float turnSpeed = 200f;
    

	// Use this for initialization
	void Start () {
        player = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * turnSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
        
	}

    void FixedUpdate()
    {
    //    player.SetFloat();   
    }
}
