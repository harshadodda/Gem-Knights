using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cust_TestPlayer : MonoBehaviour {

    public float speed = 10.0F;
    public float turnSpeed = 200.0F;
    //private Transform m_Cam;                  // A reference to the main camera in the scenes transform
    //private Vector3 m_CamForward;             // The current forward direction of the camera
    //private Vector3 m_Move;

    // Use this for initialization
    void Start()
    {
        // get the transform of the main camera
        //if (Camera.main != null)
        //{
        //    m_Cam = Camera.main.transform;
        //}
        //else
        //{
        //    Debug.LogWarning(
        //        "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
        //    // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
        //}
        //player = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * turnSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(-translation, 0, 0);
        transform.Rotate(0, rotation, 0);

    }

    void FixedUpdate()
    {
        //float h = input.getaxis("vertical") * speed;
        //float v = input.getaxis("horizontal") * turnspeed;

        //if (m_cam != null)
        //{
        //    // calculate camera relative direction to move:
        //    m_camforward = vector3.scale(m_cam.forward, new vector3(1, 0, 1)).normalized;
        //    m_move = v * m_camforward + h * m_cam.right;
        //}
        //else
        //{
        //    // we use world-relative directions in the case of no main camera
        //    m_move = v * vector3.forward + h * vector3.right;
        //}

        ////translation *= time.deltatime;
        ////rotation *= time.deltatime;
        //transform.translate(-1,0, 0);
        //transform.rotate(m_move);
    }
}



