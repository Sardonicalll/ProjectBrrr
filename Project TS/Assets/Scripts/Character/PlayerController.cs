using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour { // Plays the teleportation sound
    public float jumpDist = 5;
    public float walkingSpeed = 4.0f;

    SkinnedMeshRenderer meshRenderer;
    ParticleSystem partSystem;
    Transform center;
    CameraControl cam;
    CharacterController controller;
    public BoxCollider sword;
    float y;
    Vector3 lastValidPosition;

    AudioSource[] audio;

    // Use this for initialization
    void Start () {
        y = transform.position.y;
        cam = GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>();
        meshRenderer = this.transform.Find("PrefJoJoMesh").gameObject.GetComponent<SkinnedMeshRenderer>();
        center = this.transform.Find("center");
        partSystem = center.GetComponent<ParticleSystem>();
        controller = gameObject.GetComponent<CharacterController>();
        audio = gameObject.GetComponents<AudioSource>();
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
                audio[5].Play();
                meshRenderer.enabled = false;
                partSystem.Play(true);
                Invoke("Warp", 0.2f);
            }
        }

            //Movement
            var z = Input.GetAxis("Vertical") * Time.deltaTime * walkingSpeed;
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * walkingSpeed;
            float horizontal = Input.GetAxis("Mouse X");
            cam.setX(horizontal);
            transform.transform.Rotate(0, horizontal, 0);
            controller.Move(transform.TransformDirection(new Vector3(x, 0, z)));

        //Anti climb prevention
        if (transform.position.y != y)
        {
            transform.position = lastValidPosition;
        }
        else
        {
            lastValidPosition = transform.position;
        }
    }

    void Warp()
    {
        partSystem.Stop(true);
        transform.Translate(0, 0, jumpDist);
        meshRenderer.enabled = true;
    }
}
