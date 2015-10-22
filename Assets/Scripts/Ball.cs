using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Vector3 launchVelocity = new Vector3(0, 0, 1500);
	public bool inPlay = false;
	
	private Vector3 ballStartPos;
	private Rigidbody rigidBody;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
		
		ballStartPos = transform.position;
		rigidBody.useGravity = false;
	}	
	
	public void Launch(Vector3 velocity){
		inPlay = true;
		rigidBody.useGravity = true;
		rigidBody.velocity  = velocity;
		audioSource.Play();
	}
	
	public void Reset(){
		inPlay = false;
		transform.position = ballStartPos;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(rigidBody.velocity);
	}
}
	