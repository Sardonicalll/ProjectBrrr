using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMusic : MonoBehaviour
{
    // Variables
    public AudioSource menu;
    public AudioSource overworld;
    public AudioSource combat;
    public AudioSource currentSong;

    void retainBetweenScenes() { // When moving between scenes, make sure the music manager can be used between them.
        DontDestroyOnLoad(transform.gameObject);
    }

    // Play any song of your choosing.
    void play(AudioSource selection) {
        if (currentSong != null) {
            currentSong.Stop();
        }
        currentSong = selection;
        currentSong.volume = 1;
        currentSong.Play();
    }

    // Continue a paused song from where you paused it.
    void playCurr() {
        currentSong.UnPause();
    }

    // Pause the current song you're playing.
    void pauseCurr() {
        currentSong.Pause();
    }

    // Restart a song from the beginning.
    void restart() {
        currentSong.Stop();
        currentSong.Play();
    }

    // Stop the current song, and make the currentSong variable null.
    void stop() {
        currentSong.Stop();
        currentSong = null;
    }

    // Switch between the overworld and combat music.
    IEnumerator overworldSwitch()
    {
        if (currentSong != null)
        {
            // Decrease the volume of a song gradually until stopping it.
            float startVolume = currentSong.volume;
            while (currentSong.volume > 0)
            {
                currentSong.volume -= startVolume * Time.deltaTime / 2.3f;
                yield return null;
            }
            currentSong.Stop();

            if (currentSong == overworld)
            {
                currentSong = combat;
            }
            else if (currentSong == combat)
            {
                currentSong = overworld;
            }

            play(currentSong);
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
