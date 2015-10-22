using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	public int lastStandingCount = -1;
	public Text standingDisplay;
	public GameObject pinSet;
	
	private Ball ball;
	private float lastChangeTime;	//Keep track of when count number last got updated
	private int lastSettledCount = 10;
	private bool ballEnteredBox = false;
	private ActionMaster actionMaster = new ActionMaster();
	private Animator animator;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding().ToString();
		
		if (ballEnteredBox){
			UpdateStandingCountAndSettle();
		}
	}
	
	private int CountStanding(){
		int standing = 0;
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			if (pin.IsStanding()){
				standing++;
			}
		}
		
		return standing;
	}
	
	public void RaisePins(){
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.RaiseIfStanding();
		}
	}
	
	public void LowerPins(){
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.Lower();
		}
	}
	
	public void RenewPins(){
		//Makes new Pins
		Instantiate (pinSet, new Vector3(0, 30, 1829), Quaternion.identity);
	}
	
	private void UpdateStandingCountAndSettle(){
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
		int pinFall = lastSettledCount - CountStanding();
		lastSettledCount = CountStanding();
		
		ActionMaster.Action action = actionMaster.Bowl(pinFall);
	
		if (action == ActionMaster.Action.Tidy){
			animator.SetTrigger("tidyTrigger");
		} else if (action == ActionMaster.Action.EndTurn){
			animator.SetTrigger("resetTrigger");
		} else if (action == ActionMaster.Action.Reset){
			animator.SetTrigger("resetTrigger");
		} else if (action == ActionMaster.Action.EndGame){
			throw new UnityException("Don't know how to handle end game yet.");
		}
	
		ball.Reset();
		lastStandingCount = -1; // Indicates pins have settled, and ball not back in box
		ballEnteredBox = false;
		standingDisplay.color = Color.green;
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
