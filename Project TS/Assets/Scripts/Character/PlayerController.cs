using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public SkinnedMeshRenderer meshRenderer;
    public Animator animator;
    public ParticleSystem partSystem;
    public float jumpDist = 20;
    public float dist = 5;
    public Transform center;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Raycast checking infront
            Vector3 fwd = center.TransformDirection(Vector3.forward);
            RaycastHit objectHit;
            if (!Physics.Raycast(center.transform.position, fwd, out objectHit, dist + 1))
            {
                //Teleport
                meshRenderer.enabled = false;
                partSystem.Play(true);
                Invoke("warp", 0.2f);
            }
        }
        else
        {
            //Movement
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 6.0f;
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 6.0f;
            float horizontal = Input.GetAxis("Mouse X");
            transform.transform.Rotate(0, horizontal, 0);

            //Move
            transform.Translate(x, 0, z);

            // Animation stuff

            if (Input.GetKeyDown(KeyCode.F))
            {
                animator.SetTrigger("dab"); // This will be a easteregg or removed soon.
            }

            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("walking", true);
            }
            else
            {
                animator.SetBool("walking", false);
            }


        }
    }

    void warp()
    {
        partSystem.Stop(true);
        transform.Translate(0, 0, jumpDist);
        meshRenderer.enabled = true;
    }
}
