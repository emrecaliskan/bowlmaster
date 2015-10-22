using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	private float standingThreshold = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public bool IsStanding(){
		Vector3 rotationInEuler = transform.rotation.eulerAngles;
		var xTilt = rotationInEuler.x > 180f ? Mathf.Abs(rotationInEuler.x - 270f) : rotationInEuler.x;
		var zTilt = rotationInEuler.z > 180f ? Mathf.Abs(rotationInEuler.z) : rotationInEuler.z;
		return (xTilt < standingThreshold) && (zTilt < standingThreshold);
	}
}
