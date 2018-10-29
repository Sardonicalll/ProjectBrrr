using UnityEngine;

public class Stamina : MonoBehaviour {

    public float stamina = 100;
    private float maxStamina;

	// Use this for initialization
	void Start () {
        maxStamina = stamina;
	}
	
	// Update is called once per frame
	void Update () {
        if(stamina < 100)
        {
            stamina += 0.1f;
        }
        if(stamina > 100)
        {
            stamina = 100;
        }
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
