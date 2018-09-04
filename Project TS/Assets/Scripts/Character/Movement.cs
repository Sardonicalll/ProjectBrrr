using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public MeshRenderer meshRenderer;
    public ParticleSystem partSystem;
    public float jumpDist = 20;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            meshRenderer.enabled = false;
            partSystem.Play(true);
            Invoke("warp", 0.2f);
        }
        else
        {
        //    var x = Input.GetAxis("Horizontal") * Time.deltaTime * 300.0f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 6.0f;
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 6.0f;
            float horizontal = Input.GetAxis("Mouse X");
            transform.transform.Rotate(0, horizontal, 0);


            transform.Translate(x, 0, z);
        }
    }

    void warp()
    {
        partSystem.Stop(true);
        transform.Translate(0, 0, jumpDist);
        meshRenderer.enabled = true;
    }
}
