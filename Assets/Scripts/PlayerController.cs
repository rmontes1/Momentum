using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 10f;
	private bool facingRight = false;
	private Animator playerAnimator;
	private bool grounded = false;
	public Transform groundCheck;
	public float jumpForce = 200;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;


	// Use this for initialization
	void Start () {
		playerAnimator = GetComponent<Animator> ();
	}

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		playerAnimator.SetBool ("Ground", grounded);


		float move = Input.GetAxis ("Horizontal");
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		playerAnimator.SetFloat ("Speed", Mathf.Abs (move));

		if (move > 0 && !facingRight) 
			FlipPlayerSprite();
		else if( move < 0 && facingRight )
			FlipPlayerSprite ();

	}

	// Update is called once per frame
	void Update () {
		Jump();
	}

	void Jump(){
		if(grounded && Input.GetKeyDown(KeyCode.Space)){
			playerAnimator.SetBool("Ground", false);
			rigidbody2D.AddForce( new Vector2( 0, jumpForce));
		}
	}

	void FlipPlayerSprite(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
