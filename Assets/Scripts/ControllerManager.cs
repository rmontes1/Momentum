using UnityEngine;
using System.Collections;
using InControl;

//setup gamepad support
//needs to be checking when controllers are plugged in
//keep track of what player is using what controller

public class ControllerManager : MonoBehaviour {

	//public Array = InputManager.Devices[0] to query local mulitple gamepads
	public InputDevice activeController;	
	public bool usingGamePad;

	void Awake(){
		activeController = InputManager.ActiveDevice;
		CheckIfUsingGamePad();
	}

	// Use this for initialization
	void Start () {
		InputManager.Setup ();
	}
	
	// Update is called once per frame
	void Update () {
		InputManager.Update ();
		activeController = InputManager.ActiveDevice;
		CheckIfUsingGamePad ();
	}

	void CheckIfUsingGamePad(){
		if( activeController != InputDevice.Null  ){
			usingGamePad = true;
		}else{
			usingGamePad = false;
		}
	}



}
