using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResponseHandler : MonoBehaviour { // Causes sword/animal damage sound.

    Health health;
    AudioSource sound;

    public TextMeshPro TextPro;

    // Use this for initialization
    void Start () {
        health = gameObject.GetComponent<Health>();
        TextPro = this.transform.Find("healthOverlay").GetComponent<TextMeshPro>();
        sound = gameObject.GetComponent<AudioSource>();
        TextPro.text = (health.GetHealth()).ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider hit)
    {
        if(hit.name == "Sword")
        {
            health.TakeDamage(12);
            TextPro.text = (health.GetHealth()).ToString();
            sound.Play(); // Play sword hit sound
        }
    }
}
