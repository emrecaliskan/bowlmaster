using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector3 launchVelocity = new Vector3(0, 0, 500);

	private Rigidbody rigidBody;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
		
		Launch();
	}
	
	public void Launch(){
		rigidBody.velocity  = launchVelocity;
		audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
