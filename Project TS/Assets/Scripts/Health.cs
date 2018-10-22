using UnityEngine;

public class Health : MonoBehaviour {

    public float health = 100;
    private float maxHealth;

    AudioSource sound;
	void Start () {
        maxHealth = health;
        sound = gameObject.GetComponent<AudioSource>();
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.K))
        {
            health -= 5;
        }

	if (health <= 0) {
            if(gameObject.tag != "Player")
            {
                Destroy(gameObject);
            }
	}
	}

    public void TakeDamage(float amount)
    {
        health -= amount;
        sound.Play();
    }

    public float GetHealth()
    {
        if (health <= 0)
        {
            return 0;
        }
        else
        {
            return health;
        }
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }
}
