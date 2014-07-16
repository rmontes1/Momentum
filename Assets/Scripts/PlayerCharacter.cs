using UnityEngine;
using System.Collections;
using InControl;

public class PlayerCharacter : Character {

	private int comboCount;
	private const float minLeftAnalogStickXValue = 0.1f;

	void Start (){
		//cant set in base class for some reason
		playerAnimator = this.GetComponent<Animator> ();
	}

	void FixedUpdate(){

	}

	// Update is called once per frame
	void Update () {
		Jump (jumpForce);
		Move (moveSpeed);
	}

	protected override void Move( float movingSpeed ){
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		playerAnimator.SetBool ("Ground", isGrounded);

		float move = GetHorizontalInput();
		rigidbody2D.velocity = new Vector2 (move * movingSpeed, rigidbody2D.velocity.y);
		
		playerAnimator.SetFloat ("Speed", Mathf.Abs (move));
		
		if (move > 0 && !facingRight) 
			FlipPlayer();
		else if( move < 0 && facingRight )
			FlipPlayer();
	}

	//returns correct controller input value to move player horizontally
	private float GetHorizontalInput(){
		if (GameManager.controllerManager.usingGamePad) {//for gamepad
			float LeftAnalogStickXValue = GameManager.controllerManager.activeController.LeftStickX.Value;
			if( Mathf.Abs( LeftAnalogStickXValue ) > minLeftAnalogStickXValue )
				return LeftAnalogStickXValue;
			else
				return 0f;

		}else{//for keyboard
			float keyboardMovement = Input.GetAxis("Horizontal");
			return keyboardMovement;
		}
	}

}
