using UnityEngine;
using System.Collections;
using InControl;

//setup gamepad support
//needs to be checking when controllers are plugged in
//keep track of what player is using what controller

public class ControllerManager : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		InputManager.Setup ();
	}
	
	// Update is called once per frame
	void Update () {
		InputManager.Update ();
	}
}
