using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : playAudio {

    // Variables
        // Footsteps
        public AudioSource humanStep;
        public AudioSource dogStep;
        // Damage
        public AudioSource humanHit;
        public AudioSource dogHit;
        public AudioSource slash;
        // Teleport
        public AudioSource teleport;

    public void Start()
    { // Method that'll run immediately on startup.
        AudioSource[] audioSources = GetComponents<AudioSource>();
        humanStep = audioSources[0];
        humanHit = audioSources[1];
        dogStep = audioSources[2];
        dogHit = audioSources[3];
        slash = audioSources[4];
        teleport = audioSources[5];
    }

    // Play any song of your choosing.
    public void play(AudioSource selection, float volume) {
        if (selection != null)
        {
            selection.Stop();
        }
        selection.volume = volume;
        selection.Play();
    }

    // Call upon Step
    public void stepJojo() {
        play(humanStep, 0.3f);
    }

    public void stepPugatoo() {
        play(dogStep, 0.5f);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Mouse0))
        {
            play(slash, 0.5f);
        }

    }
}
