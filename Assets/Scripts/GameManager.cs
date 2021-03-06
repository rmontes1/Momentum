﻿using UnityEngine;
using System.Collections;


[RequireComponent (typeof(ControllerManager))]
public class GameManager : MonoBehaviour {

	public static GameManager gameManager;
	public static ControllerManager controllerManager;

	void Awake(){
		if( gameManager == null ){

			DontDestroyOnLoad(gameObject);
			Init();
			gameManager = this;
		}
		else if(gameManager != this ){
			Destroy(gameObject);
		}

	}

	//setup gamemanager references
	void Init(){
		controllerManager = this.GetComponent<ControllerManager> ();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
