using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PugatooAI : MonoBehaviour {


    Transform player;
    NavMeshAgent agent;

    Vector3 curPos;
    Vector3 lastPos;

    Quaternion curRot;
    Quaternion lastRot;

    // Use this for initialization
    void Start () {
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

    }

}

