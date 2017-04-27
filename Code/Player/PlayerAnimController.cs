using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAnimController : MonoBehaviour
{

    Animator anim;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("1"))
            anim.SetTrigger("isDamaged");
        if (Input.GetKey("2"))
            anim.SetTrigger("isRunning");
        if (Input.GetKey("3"))
            GetComponent<Animation>().CrossFade("Run");
        if (Input.GetKey("4"))
            GetComponent<Animation>().CrossFade("Attack_Magic");
        if (Input.GetKey("5"))
            GetComponent<Animation>().CrossFade("Attack_Sword");
        if (Input.GetKey("6"))
            GetComponent<Animation>().CrossFade("Damage");
    }


}
