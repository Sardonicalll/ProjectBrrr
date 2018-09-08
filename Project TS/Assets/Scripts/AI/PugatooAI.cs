using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PugatooAI : MonoBehaviour {


    public Animator animator;
    public Transform player;
    public Rigidbody rigid;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (rigid.velocity.magnitude>0)
        {
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .03f);
    }
}
