using UnityEngine;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour { // Animal damaged sound now in ResponseHandler.cs

    public float health = 100;
    private float maxHealth;
    bool played = false;

	void Start () {
        maxHealth = health;
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
            else
            {
                if (!played)
                {
                    played = true;
                    gameObject.GetComponent<PlayerController>().ToggleMove();
                    gameObject.GetComponent<PlayerController>().Die();
                    Invoke("Restart", 4f);
                }
            }
	}
	}

    public void TakeDamage(float amount)
    {
        health -= amount;
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

    public void Restart()
    {
        gameObject.GetComponent<PlayerController>().ToggleMove();
        SceneManager.LoadScene(0);
    }
}
