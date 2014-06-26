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

	protected override void Move( float movingSpeed ){
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		playerAnimator.SetBool ("Ground", isGrounded);
		
		
		float move = Input.GetAxis ("Horizontal");
		rigidbody2D.velocity = new Vector2 (move * movingSpeed, rigidbody2D.velocity.y);
		
		playerAnimator.SetFloat ("Speed", Mathf.Abs (move));
		
		if (move > 0 && !facingRight) 
			FlipPlayer();
		else if( move < 0 && facingRight )
			FlipPlayer();
	}

}
