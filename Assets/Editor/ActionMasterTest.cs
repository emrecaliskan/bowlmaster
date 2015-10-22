﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
[Category("Sample Tests")]
public class ActionMasterTest {

	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	
	[Test]
	public void PassingTest(){
		Assert.AreEqual(1, 1);
	}
	
	[Test]
	public void T01_OneStrikeReturnsEndTurn(){
	ActionMaster actionMaster = new ActionMaster();
		Assert.AreEqual (endTurn, actionMaster.Bowl(10));
	}
	

}
