﻿using UnityEngine;
using System.Collections;

public class ActionMaster {

	public enum Action {Tidy, Reset, EndTurn, EndGame};
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public Action Bowl (int pins){
		if (pins < 0 || pins > 10){ throw new UnityException("Invalid pins."); }
	
		if (pins == 10){
			return Action.EndTurn;
		}
		
		throw new UnityException ("Not sure what action to return.");
	}
}
