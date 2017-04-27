using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

  
    public GameObject target;
    private float attackTimer;
    public float coolDown;
    public int damage;
    // Use this for initialization
    void Start () {
        attackTimer = 0;
	}

    void Awake()
    {
        setPlayerObject();
    }
	
	// Update is called once per frame
	void Update () {

        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;

        if (attackTimer < 0)
            attackTimer = 0;

            if (attackTimer == 0)
            {
                Attack();
                attackTimer = coolDown;
            }
	}

    void setPlayerObject()
    {
        GameObject go = GameObject.FindGameObjectWithTag("PlayerCombat");
        if (go != null)
        {
            target = go.transform.gameObject;
        }
        else
        {
            Debug.Log("Player Combat Not Found");
        }
    }

 

    private void Attack()
    {

        float distance = Vector3.Distance(target.transform.position, transform.position);
        Vector3 dir = (target.transform.position - transform.position).normalized;

        float direction = Vector3.Dot(dir, transform.forward);


        if (distance < 3 && (direction > 0))
        {
            PlayerHealth eh = (PlayerHealth)target.GetComponent("PlayerHealth");

            eh.AdjustCurrentHealth(damage);
        }
    }

}
