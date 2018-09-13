using UnityEngine;
using UnityEngine.UI;

public class HudUpdater : MonoBehaviour {

    PlayerHealth ph;
    PlayerStamina ps;

    public Text hpT;
    public Text stT;

	// Use this for initialization
	void Start () {
        GameObject player = GameObject.FindWithTag("Player");
        ph = player.GetComponent<PlayerHealth>();
        ps = player.GetComponent<PlayerStamina>();
    }
	
	// Update is called once per frame
	void Update () {
        hpT.text = "HP: " + ph.GetHealth().ToString();
        stT.text = "Stamina: " + ps.GetStamina().ToString();
	}
}
