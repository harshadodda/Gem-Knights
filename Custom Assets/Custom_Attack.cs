using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom_Attack : MonoBehaviour {

    public GameObject target;
    public float attackTimer;
    public float coolDown;
    public int damage;
    // Use this for initialization
    void Start()
    {
        attackTimer = 0;
        target = null;
    }

    // Update is called once per frame
    void Update()
    {

        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;

        if (attackTimer < 0)
            attackTimer = 0;


        if (Input.GetMouseButton(0))
        {
            if (attackTimer == 0)
            {
                Attack();
                attackTimer = coolDown;
            }

        }

    }


    private void Attack()
    {

        if (target == null)
            return;

        float distance = Vector3.Distance(target.transform.position, transform.position);
        Vector3 dir = (target.transform.position - transform.position).normalized;

        float direction = Vector3.Dot(dir, -transform.forward);


        if (distance < 6 && (direction > 0))
        {
            EnemyHealth eh = (EnemyHealth)target.GetComponent("EnemyHealth");

            eh.AdjustCurrentHealth(-damage);
        }
    }
}
