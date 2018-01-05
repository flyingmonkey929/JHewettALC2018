using UnityEngine;
using System.Collections;

public class BatteryScript : MonoBehaviour {


	public int power = 4;

	GameObject player;

	GameObject batterySpawn;

	int checkBat;

	public GameObject flashlight;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		batterySpawn = GameObject.FindWithTag("BatterySpawn");
		flashlight = player;

		

	
	}
	
	// Update is called once per frame
	void Update () {
		checkBat = flashlight.gameObject.GetComponentInChildren<FlashLight>().currentPower;
		print("CKBat =" +checkBat);
	
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Player" && checkBat == 0){
			flashlight.gameObject.GetComponentInChildren<FlashLight>().currentPower = power;
			Destroy(gameObject);
			batterySpawn.gameObject.GetComponentInChildren<BatterySpawn>().BatteryPickup();
		}


	}


}
