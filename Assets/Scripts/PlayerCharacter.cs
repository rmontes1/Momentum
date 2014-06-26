using UnityEngine;
using System.Collections;

public class PlayerCharacter : Character {

	private int comboCount;

	void Start (){
		//cant set in base class for some reason
		playerAnimator = this.GetComponent<Animator> ();
	}

	void FixedUpdate(){
		Jump (jumpForce);
	}

	// Update is called once per frame
	void Update () {
		Move (moveSpeed);
	}


}
