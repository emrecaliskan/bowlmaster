using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	private float standingThreshold = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		print(isStanding());
	}
	
	public bool isStanding(){
		Vector3 rotationInEuler = transform.rotation.eulerAngles;
		var xTilt = rotationInEuler.x > 180f ? Mathf.Abs(rotationInEuler.x - 360f) : rotationInEuler.x;
		var zTilt = rotationInEuler.z > 180f ? Mathf.Abs(rotationInEuler.z - 360f) : rotationInEuler.z;
		return (xTilt < standingThreshold) && (zTilt < standingThreshold);
	}
}
