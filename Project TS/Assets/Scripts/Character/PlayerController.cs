using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float jumpDist = 5;
    public float walkingSpeed = 4.0f;

    SkinnedMeshRenderer meshRenderer;
    public GameObject cama;
    Animator animator;
    ParticleSystem partSystem;
    Transform center;
    CameraControl cam;

    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponent<Animator>();
        cam = cama.GetComponent<CameraControl>();
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
                    animator.SetFloat("walkingSpeed", -1);
                }
                else
                {
                    animator.SetFloat("walkingSpeed", 1);
                }

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
