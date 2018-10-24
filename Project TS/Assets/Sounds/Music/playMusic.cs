using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMusic : playAudio {
    // Variables
    public AudioClip menu;
    public AudioClip overworld;
    public AudioClip combat;

    void retainBetweenScenes() { // When moving between scenes, make sure the music manager can be used between them.
        DontDestroyOnLoad(transform.gameObject);
    }

    // Play any song of your choosing.
    void play(AudioClip selection) {
        if (currentAudio != null) {
            currentAudio.Stop();
        }
        currentAudio.clip = selection;
        currentAudio.volume = 1;
        currentAudio.Play();
    }

    // Continue a paused song from where you paused it.
    void playCurr() {
        currentAudio.UnPause();
    }

    // Pause the current song you're playing.
    void pauseCurr() {
        currentAudio.Pause();
    }

    // Restart a song from the beginning.
    void restart() {
        currentAudio.Stop();
        currentAudio.Play();
    }

    // Stop the current song, and make the currentAudio variable null.
    void stop() {
        currentAudio.Stop();
        currentAudio = null;
    }

    // Switch between the overworld and combat music.
    IEnumerator overworldSwitch()
    {
        if (currentAudio != null)
        {
            // Decrease the volume of a song gradually until stopping it.
            float startVolume = currentAudio.volume;
            while (currentAudio.volume > 0)
            {
                currentAudio.volume -= startVolume * Time.deltaTime / 2.3f;
                yield return null;
            }
            currentAudio.Stop();

            if (currentAudio == overworld)
            {
                currentAudio.clip = combat;
            }
            else if (currentAudio == combat)
            {
                currentAudio.clip = overworld;
            }

            currentAudio.Play();
        }
    }

    // Debug Keypress Commands
    private void Update()
    {
        // Overworld Switch Test
        if (Input.GetKeyDown(KeyCode.O)) {
            StartCoroutine(overworldSwitch());
        }

        // Play Any Song From the OST
        if (Input.GetKeyDown(KeyCode.Keypad1))
        { // Keypad 1
            play(menu);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        { // Keypad 2
            play(overworld);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        { // Keypad 3
            play(combat);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        { // Keypad 4
            play(menu); // Bulgertan
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        { // Keypad 5
            play(menu); // Credits
        }
    }
}
