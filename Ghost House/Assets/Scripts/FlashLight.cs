using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour {

	public bool lightOn = true;
	// Flashlight power capacity
	public int maxPower = 4;
	// Usable flashlight power
	public int currentPower;
	// How much the battery drains
	public int batDrainAmt;
	// How long to the batery drains
	public float batDrainDelay;

	Light light;

	public Text batteryText;

	bool draining = false;

	long count = 0;

	

	

	// Use this for initialization
	void Start () {
		//Add power to flashlight
		currentPower = maxPower;
		print("Power = " + currentPower);

		light = GetComponent<Light> ();

		lightOn = true;
		light.enabled = true;
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyUp (KeyCode.L) && lightOn){
		print("Light Off");
		lightOn = false;
		light.enabled = false;

	}

	else if (Input.GetKeyUp (KeyCode.L) && !lightOn){
		print("Light On");
		lightOn = true;
		light.enabled = true;
	}

	//Update Battery UI text
	batteryText.text = currentPower.ToString();
	
	//Drain Battery Life
	if(currentPower > 0 && lightOn){
			if(!draining){
				StartCoroutine(BatteryDrain(batDrainDelay,batDrainAmt));
			}
			else if(currentPower <= 0){
				lightOn = false;
				light.enabled = false;
			}
		
			}
		
		}
	
	public void setLightOn(){
		lightOn = true;

	}
	public bool isLightOn(){
		return lightOn;
	}

	IEnumerator BatteryDrain(float delay, int amount){
		if(lightOn){
			draining = true;
			yield return new WaitForSeconds(delay);
			print(currentPower);
			currentPower -= amount;
		}

		if(currentPower <= 0){
			currentPower = 0;
			print("Battery is Dead!");
			light.enabled = false;
		}

		draining = false;
		
			
		
	}
}