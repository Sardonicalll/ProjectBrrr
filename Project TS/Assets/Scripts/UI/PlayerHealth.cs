using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

public int maxhealth;
private int currenthealth;
private int takendmg;
public Text hptxt;

public Text death;

	void Start () {
		maxhealth = 100;
		takendmg = 0;
		currenthealth =  maxhealth;
		hptxt.text = "HP: " + currenthealth.ToString();
	}
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.K))
        {
			currenthealth = currenthealth - 10;
            hptxt.text = "HP:" + currenthealth.ToString();
        }

	if (currenthealth <= 0) {
		death.text = "ded";

	}
	}
}
