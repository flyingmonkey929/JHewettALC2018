using UnityEngine;
using System.Collections;

public class BatteryScript : MonoBehaviour {


	public int power = 4;

	public GameObject flashlight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Player"){
			flashlight.gameObject.GetComponentInChildren<FlashLight>().currentPower = power;
			Destroy(gameObject);
		}


	}


}
