using UnityEngine;
using System.Collections;


[RequireComponent (typeof (Animator))]
[RequireComponent (typeof (Rigidbody2D))]
public class Character : MonoBehaviour {


	//should we keep track of maxSpeed, currentSpeed, defaultSpeed, minSpeed
	public float moveSpeed;
	public float attackSpeed;
	public float attackPower;
	public float attackRange;
	public float jumpForce;
	public Transform groundCheck;
	public LayerMask whatIsGround;

	//made all protected because we want to let our child classes access these varibles
	//but not make it avaible to public or inspector
	protected Animator playerAnimator;
	protected int health, maxHealth, currentHealth;//thought we need seperarte trackers
	protected int hitsTaken, hitsBlocked, hitsMissed, timesJumped;
	protected int lives;
	protected int deaths;
	protected float groundRadius;
	protected bool isAttacking, isBlocking, isStunned, isKnockedBack, isGrounded;
	protected bool facingRight;
	protected bool isDead;
	protected bool canJump;
	protected bool canAttack;
	protected bool canBlock;



	// Use this for initialization
	void Start () {

	}  
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Jump( float jumpForceAmount ){
		if( isGrounded && Input.GetKeyDown(KeyCode.Space)){
			playerAnimator.SetBool("Ground", false);
			rigidbody2D.AddForce( new Vector2( 0, jumpForceAmount ));
		}
	}

	//might want to make virtual or override to allow the 2 kinds of moves to be implemented
	//player and npc / AI
	public void Move( float movingSpeed ){
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

	public void Interact(){

	}

	private void FlipPlayer(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
