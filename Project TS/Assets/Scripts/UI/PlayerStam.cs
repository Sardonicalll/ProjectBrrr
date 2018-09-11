using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStam : MonoBehaviour {

public int maxstam;
public int currentstam;
private int stamloss;

public Text stamtxt;

	// Use this for initialization
	void Start () {
		currentstam = maxstam;
        stamtxt.text = "Stam:" + currentstam.ToString();
	}
	
	// Update is called once per frame
	void Update () {

		if (currentstam > 0 )
		{
        	if (Input.GetKeyDown(KeyCode.Space))
       	 	{
			stamloss = 10;
            currentstam = currentstam - stamloss;
            stamtxt.text = "Stam:" + currentstam.ToString();
      	 	}
		}
	}
}
