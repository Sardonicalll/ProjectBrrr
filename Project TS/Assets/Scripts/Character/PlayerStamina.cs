﻿using UnityEngine;

public class PlayerStamina : MonoBehaviour {

    public float stamina = 100;
    private float maxStamina;

	// Use this for initialization
	void Start () {
        maxStamina = stamina;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Exhaust(float amount)
    {
        stamina -= amount;
    }

    public float GetStamina()
    {
        return stamina;
    }

    public float GetMaxStamina()
    {
        return maxStamina;
    }
}
