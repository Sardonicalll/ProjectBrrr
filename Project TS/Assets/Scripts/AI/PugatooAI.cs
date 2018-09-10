using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PugatooAI : MonoBehaviour {


    public Animator animator;
    public Transform player;
    public NavMeshAgent agent;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
            if(agent.SetDestination(player.transform.position)){
                animator.SetBool("walking", true);
            }
            else
            {
                animator.SetBool("walking", false);
            }

    }
}

