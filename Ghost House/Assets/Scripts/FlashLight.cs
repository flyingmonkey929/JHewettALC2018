using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlashLight : MonoBehaviour {

	public bool LightOn;

	Light light;

	// Use this for initialization
	void Start () 
	{
		light = GetComponent<Light> ();

		lightOn = true;
		light.enabled = true;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	if(Input.GetKeyUp (Key.Code.L) && lightOn){
		lightOn = false;
		light.enabled = false;

	}
	else if (Input.GetKeyUp (KeyCode.L) && !lightOn){
		lightOn = true;
		light.enabled = true;
	}
		
		}
	}
}
