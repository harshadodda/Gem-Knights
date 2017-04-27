
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    public GameObject player;
   
    void Start()
    {
        player.SetActive(false);
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Cursor.visible = false;
            player.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
