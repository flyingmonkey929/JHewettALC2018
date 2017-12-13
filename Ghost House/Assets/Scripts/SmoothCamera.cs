using UnityEngine;
using System.Collections;

public class SmoothCamera : MonoBehaviour {
	public Transform target;
	public Vector3 defaultDistance = new Vector3(0f,2f,-10f);
	public float distanceDamp = 10f;
	public float rotationalDamp = 10f;





	Transform myT;

	void Awake()
	{
		myT = transform;

	}
	void LateUpdate()
	{
		Vector3 toPos = target.position + (target.rotation * defaultDistance);
		Vector3 curPos = Vector3.Lerp(myT.position, toPos, distanceDamp * Time.deltaTime);
		myT.position = curPos;

		Quaternion toRot = Quaternion.LookRotation(target.position - myT.position, target.up);
		Quaternion curRot = Quaternion.Slerp(myT.rotation, toRot, rotationalDamp * Time.deltaTime);
		myT.rotation = curRot;
		
	}
	
}
