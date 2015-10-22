using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	private float standingThreshold = 3f;
	private float distToRaise = 40f;

	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
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
	
	public void RaiseIfStanding(){
		if(IsStanding()){
			rigidBody.useGravity = false;
			rigidBody.isKinematic = true;
			transform.Translate(new Vector3(0, distToRaise, 0), Space.World);
		}
	}
	
	public void Lower(){
		rigidBody.isKinematic = false;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
		rigidBody.useGravity = true;
	}
}
