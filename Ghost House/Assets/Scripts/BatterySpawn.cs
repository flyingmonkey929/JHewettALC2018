using UnityEngine;
using System.Collections;

public class BatterySpawn : MonoBehaviour {

	public Rigidbody battery;

	public Transform spawnPoint;

	public float spawnTime;

	public bool batSpawned;




	// Use this for initialization
	void Start () {
			batSpawned = false;
	
	}
	
	// Update is called once per frame
	void Update () {
			if(batSpawned == false){
				StartCoroutine(SpawnBat(spawnTime, battery));

			}
			else if(batSpawned == true){
				StopCoroutine(SpawnBat(spawnTime, battery));

			}
	
	}

	void OnTriggerStay(Collider other){
		if(other.gameObject.tag == "Battery"){
			print("Battery is in the trigger");
			batSpawned = true;

		}
		else{
			batSpawned = false;

		}
	}

	IEnumerator SpawnBat(float time, Rigidbody bat){
		yield return new WaitForSeconds(time);
		Instantiate(bat, spawnPoint.position, spawnPoint.rotation);
		batSpawned = true;
	}

}
