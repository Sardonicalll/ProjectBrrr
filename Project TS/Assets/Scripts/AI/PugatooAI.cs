using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PugatooAI : MonoBehaviour {


    Animator animator;
    Transform player;
    NavMeshAgent agent;

    Vector3 curPos;
    Vector3 lastPos;

    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponent<Animator>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(player.transform.position);
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
}

