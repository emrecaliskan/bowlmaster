﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	public int lastStandingCount = -1;
	public Text standingDisplay;
	private float distanceToRaise = 40f;
	
	private Ball ball;
	private float lastChangeTime;	//Keep track of when count number last got updated
	private bool ballEnteredBox = false;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding().ToString();
		
		if (ballEnteredBox){
			CheckStanding();
		}
	}
	
	private int CountStanding(){
		int standing = 0;
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			if (pin.IsStanding())
				standing++;
		}
		
		return standing;
	}
	
	private void CheckStanding(){
		// Update the last standing count
		// Call PinsHaveSettled, when they have
		int currentStanding = CountStanding();
		
		if (currentStanding != lastStandingCount){
			lastChangeTime = Time.time; //Time.time is time since game started
			lastStandingCount = currentStanding;
			return;
		}
		
		float settleTime = 3f;	// How long to wait to consider pins settled
		if ((Time.time - lastChangeTime) > settleTime){ // If last change is more than settle Time
			PinsHaveSettled();
		}
	}
	
	void PinsHaveSettled(){
		ball.Reset();
		lastStandingCount = -1; // Indicates pins have settled, and ball not back in box
		ballEnteredBox = false;
		standingDisplay.color = Color.green;
	}
	
	void OnTriggerExit(Collider collider){
		GameObject thingLeft = collider.gameObject;
		
		if (thingLeft.GetComponent<Pin>()){
			Debug.Log("CAlled");
			Destroy(thingLeft);
		}
	}
	
	void OnTriggerEnter (Collider collider){
		GameObject thingHit = collider.gameObject;
		
		// Ball enters play box
		if (thingHit.GetComponent<Ball>()){
			ballEnteredBox = true;
			standingDisplay.color = Color.red;
		}
	}
	
}
