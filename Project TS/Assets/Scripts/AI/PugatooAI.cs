using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PugatooAI : MonoBehaviour { // Playing the human damaged sound effect

    Transform player;
    NavMeshAgent agent;

    Vector3 curPos;
    Vector3 lastPos;

    Quaternion curRot;
    Quaternion lastRot;

    Animator animator;

    bool aggro = false;

    public float aggroRange = 5.3f;
    public float attackRange = 1.3f;
    public float biteDamage = 5;

    public float attackDelay = 1;
    float lastAttack = 0;

    public AudioSource[] sound;

    // Use this for initialization
    void Start () {
        agent = gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
        animator = this.GetComponent<Animator>();
        sound = GetComponents<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        var dist = Vector3.Distance(this.transform.position, player.transform.position);
        if (!aggro && dist <= aggroRange)
        {
            aggro = true;
        }

        if (aggro)
        {
            if (dist <= attackRange)
            {
                Attack();
            }else
            {
                agent.SetDestination(player.transform.position);
            }
        }
       
    }

    public bool HasMoved()
    {
        curPos = transform.position;
        if (curPos == lastPos)
        {
            return false;
        }
        lastPos = curPos;
        return true;
    }

    public bool HasRotated()
    {
        curRot = transform.rotation;
        if (curRot == lastRot)
        {
            return false;
        }
        lastRot = curRot;
        return true;
    }

    void Attack()
    {
        if (Time.time > lastAttack)
        {
            transform.LookAt(player);
            animator.SetTrigger("Lunge");
            player.GetComponent<Health>().TakeDamage(biteDamage);
            sound[1].Play();

            lastAttack = Time.time + attackDelay;
        }
 
    }

}

