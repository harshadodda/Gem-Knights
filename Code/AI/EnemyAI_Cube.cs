using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_Cube : MonoBehaviour
{


    public int moveSpeed;
    public int rotationSpeed;
    public int maxDistance;

    private Transform target;
    private Transform myTransform;

    private GameObject playerObject;
    void Awake()
    {
        myTransform = transform;
    }
    // Use this for initialization
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");

        target = playerObject.transform;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawLine(target.position, myTransform.position, Color.blue);

        // Look at target
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

        // Move towards player
        if (Vector3.Distance(myTransform.position, target.position) > maxDistance)
        myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
    }
}
