using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudio : MonoBehaviour {

    // Variables
    public AudioSource currentAudio; // Audio that's currently playing

    public void Start() { // Method that'll run immediately on startup.
        AudioSource[] audioSources = GetComponents<AudioSource>();
        currentAudio = audioSources[0];
    }

    // Play any audio of your choosing.
    public void play(AudioClip selection, float volume) {
        currentAudio.clip = selection;
        currentAudio.volume = volume;
        currentAudio.Play();
    }
}
