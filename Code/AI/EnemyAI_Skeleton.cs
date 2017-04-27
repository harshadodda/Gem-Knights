using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI_Skeleton : MonoBehaviour {
    Renderer enemySkin;
    Collider bodyCollider;
    EnemyHealth enemyHealth;
    public Transform player;
    public Animator anim;
    private float distance;
    private float lookDistance;
    private float walkDistance;
    private float runDistance;
    private float attackDistance;
    private bool killTimer = false;
    private float deathTimer = 10.0f;
    public bool alive = true;
    public bool damaged = false;
    private bool playDeathAnimOnce = true;
    private bool prev = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
        bodyCollider = this.GetComponent<Collider>();

        lookDistance = 50f;
        walkDistance = 40f;
        runDistance = 25f;
        attackDistance = 4.3f;
        setPlayerObject();
    }


    private void FixedUpdate()
    {
        if (alive)
        {
            distance = Vector3.Distance(player.position, this.transform.position);
            if (damaged ) isDamaged();
            else if (distance < attackDistance) attack();
            else if (distance < runDistance) alert();
            else if (distance < walkDistance) caution();
            else if (distance < lookDistance) look();
            else idle();
        }
        else killEnemy();
    }



    void killEnemy()
    {
        if (playDeathAnimOnce != prev)
        {
            aniSet("isDead");
            killTimer = true;
            prev = playDeathAnimOnce;
        }
        if (killTimer)
        {
            deathTimer -= Time.deltaTime;
            if (deathTimer < 6.5f)
            {
                bodyCollider.enabled = false;

				PlayerPrefs.SetInt("skelKillCount", PlayerPrefs.GetInt ("skelKillCount", 0) + 1);
			
            }
            
        }
        if (deathTimer < 0) gameObject.SetActive(false);
    }



    void turnTowardPlayer()
    {
        Vector3 direction = player.position - this.transform.position;
        direction.y = 0;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
    }

    void setPlayerObject()
    {
        GameObject go = GameObject.FindGameObjectWithTag("PlayerCombat");
        if (go != null)
        {
            player = go.transform;
        }
        else
        {
            Debug.Log("Player Combat Not Found");
        }
    }


    void look()
    {
        aniSet("isStanding");
        turnTowardPlayer();
    }


    float damageTimer = 10.0f;
    bool tookDamage = false;
    void isDamaged()
    {

        aniSet("isDamaged");

        damaged = false;
    }

    void caution()
    {
        aniSet("isWalking");
        turnTowardPlayer();
        this.transform.Translate(0, 0, 0.05f);
    }


    void alert()
    {
        if (distance < 7)
        {
            aniSet("isWalking");
            turnTowardPlayer();
            this.transform.Translate(0, 0, 0.04f);
        }
        else
        {
            aniSet("isRunning");
            turnTowardPlayer();
            this.transform.Translate(0, 0, 0.12f);
        }
    }

    void attack()
    {
        aniSet("isAttacking");
    }

    void idle()
    {
        aniSet("isIdle");
    }


    void aniSet(string state)
    {
        anim.SetBool("isIdle", false);
        anim.SetBool("isStanding", false);
        anim.SetBool("isWalking", false);
        anim.SetBool("isRunning", false);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isDamaged", false);
        anim.SetBool(state, true);
    }
}
