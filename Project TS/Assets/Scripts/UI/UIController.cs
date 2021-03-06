﻿using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    Health ph;
    Stamina ps;

    public RawImage dhBG;
    public Text dhT;

    public Text hpT;
    public Slider hpS;

    public Text stT;
    public Slider stS;
   

    // Use this for initialization
    void Start () {
        GameObject player = GameObject.FindWithTag("Player");
        ph = player.GetComponent<Health>();
        ps = player.GetComponent<Stamina>();
    }
	
	// Update is called once per frame
	void Update () {
        float health = ph.GetHealth();
        float stamina = ps.GetStamina();
        float maxHealth = ph.GetMaxHealth();
        float maxStamina = ps.GetMaxStamina();

        hpT.text = decimal.Round(((decimal)(health / maxHealth) * 100), 1).ToString() + "%";
        stT.text = decimal.Round(((decimal)(stamina / maxStamina) * 100),1).ToString() + "%";

        hpS.value = 1 - (health / maxHealth);
        stS.value = 1 - (stamina / maxStamina);


        if(health <= 0)
        {
            dhT.text = "GIT GUD SCRUB";
            dhBG.enabled = true;
        }
	}
}
