using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

   public MeshRenderer a;
    public ParticleSystem ps;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            a.enabled = false;
            ps.Play(true);
            Invoke("warp", 0.2f);
        }
        else
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 300.0f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 6.0f;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);
        }
    }

    void warp()
    {
        ps.Stop(true);
        transform.Translate(0, 0, 20);
        a.enabled = true;
    }
}
