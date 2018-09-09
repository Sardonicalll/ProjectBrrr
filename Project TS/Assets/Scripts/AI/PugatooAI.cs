using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PugatooAI : MonoBehaviour {


    public Animator animator;
    public Transform player;
    public Rigidbody rigid;

    public float Speed = .03f;
    public float lookDelay = 1;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 target = player.transform.position;
        if (Vector3.Distance(transform.position, target) > 2 )
        {
            animator.SetBool("walking", true);
            transform.position = Vector3.MoveTowards(transform.position, target, Speed);
        }
        else
        {
            animator.SetBool("walking", false);
        }

        var lookPos = target - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, lookDelay);

    }



    // Slow turn (Maybe)
    //Vector3 DirectionXZ()
    //{
    //    Quaternion targetRotation = Quaternion.LookRotation(DirectionXZ());
    //    transform.rotation = Quaternion.RotateTowards(transform.rotation,
    //        targetRotation, 40 * Time.deltaTime);

    //    Vector3 direction = player.position - transform.position;
    //    direction.y = 0; // Ignore Y
    //    return direction;
    //}
}

