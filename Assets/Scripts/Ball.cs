using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector3 launchVelocity = new Vector3(0, 0, 1500);

	public bool inPlay = false;
	private Rigidbody rigidBody;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
		
		
		rigidBody.useGravity = false;
	}	
	
	public void Launch(Vector3 velocity){
		inPlay = true;
		rigidBody.useGravity = true;
		rigidBody.velocity  = velocity;
		audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
	