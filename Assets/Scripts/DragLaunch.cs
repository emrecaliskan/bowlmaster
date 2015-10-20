using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {

	private Ball ball;
	private Vector3 dragStart, dragEnd;
	private float startTime, endTime;

	// Use this for initialization
	void Start () {
		ball = GetComponent<Ball>();
	}
	
	public void DragStart () {
		//Capture time & position of mouse click
		dragStart = Input.mousePosition;
		startTime = Time.time;
	}
	
	public void DragEnd () {
		// Launch the ball
		dragEnd = Input.mousePosition;
		endTime = Time.time;
		
		float dragDuration = endTime - startTime;
		float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
		float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;
		
		Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
		ball.Launch(launchVelocity);
	}
}
