using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResponseHandler : MonoBehaviour {

    Health health;
    AudioSource sound;

    public TextMeshPro TextPro;


    // Use this for initialization
    void Start () {
        health = gameObject.GetComponent<Health>();
        sound = gameObject.GetComponent<AudioSource>();
        TextPro = this.transform.Find("healthOverlay").GetComponent<TextMeshPro>();

        TextPro.text = (health.GetHealth()).ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider hit)
    {
        if(hit.name == "Sword")
        {
            health.TakeDamage(5);
            TextPro.text = (health.GetHealth()).ToString();
            sound.Play();
        }
    }
}
