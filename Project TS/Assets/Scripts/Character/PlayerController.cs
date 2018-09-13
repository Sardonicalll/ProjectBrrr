using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float jumpDist = 5;
    public float walkingSpeed = 4.0f;

    SkinnedMeshRenderer meshRenderer;
    Animator animator;
    ParticleSystem partSystem;
    Transform center;
    CameraControl cam;

    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponent<Animator>();
        cam = GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>();
        meshRenderer = this.transform.Find("PrefJoJoMesh").gameObject.GetComponent<SkinnedMeshRenderer>();
        center = this.transform.Find("center");
        partSystem = center.GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Raycast checking infront
            Vector3 fwd = center.TransformDirection(Vector3.forward);
            RaycastHit objectHit;
            if (!Physics.Raycast(center.transform.position, fwd, out objectHit, jumpDist + 1))
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
            var z = Input.GetAxis("Vertical") * Time.deltaTime * walkingSpeed;
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * walkingSpeed;
            float horizontal = Input.GetAxis("Mouse X");
            cam.setX(horizontal);
            transform.transform.Rotate(0, horizontal, 0);

            //Move
            transform.Translate(x, 0, z);

            // Animation stuff

            if (Input.GetKeyDown(KeyCode.F))
            {
                animator.SetTrigger("dab"); // This will be a easteregg or removed soon.
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.S))
                {
                    animator.SetFloat("walkingSpeed", -1.6f);
                }
                else
                {
                    animator.SetFloat("walkingSpeed", 1.6f);
                }

                animator.SetBool("walking", true);
            }
            else
            {
                animator.SetBool("walking", false);
            }


            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    animator.SetFloat("stepSpeed", -3.2f);
                }
                else
                {
                    animator.SetFloat("stepSpeed", 3.2f);
                }

                animator.SetBool("step", true);
            }
            else
            {
                animator.SetBool("step", false);
            }

            if (Input.GetKey("up") || Input.GetKey("down"))
            {
                if (Input.GetKey("down"))
                {
                    animator.SetFloat("spinSpeed", -3f);
                }
                else
                {
                    animator.SetFloat("spinSpeed", 3f);
                }

                animator.SetBool("spin", true);
            }
            else
            {
                animator.SetBool("spin", false);
            }

            if (Input.GetKey("left") || Input.GetKey("right"))
            {
                if (Input.GetKey("left"))
                {
                    animator.SetFloat("spinSideSpeed", -6f);
                }
                else
                {
                    animator.SetFloat("spinSideSpeed", 6f);
                }

                animator.SetBool("spinSide", true);
            }
            else
            {
                animator.SetBool("spinSide", false);
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
