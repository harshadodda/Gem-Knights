using UnityEngine;
using System.Collections;

public class PlayerLight : MonoBehaviour
{
    private Light myLight;


    void Start()
    {
        myLight = GetComponent<Light>();
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            myLight.enabled = !myLight.enabled;
        }
    }
}