using UnityEngine;
using System.Collections;
using InControl;


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

	//Applies Jump based on either key or gamepad usage
	public void Jump( float jumpForceAmount ){
		//doesnt register the button all the time since its in FixedUpdate
		//But need it in here because it uses physics 
		if( GameManager.controllerManager.usingGamePad ){
			if( isGrounded && GameManager.controllerManager.activeController.Action1.WasPressed ){
				playerAnimator.SetBool("Ground", false);
				rigidbody2D.AddForce( new Vector2( 0, jumpForceAmount ));
			}
		}else{
			if( isGrounded && Input.GetButtonDown("Jump")){
				playerAnimator.SetBool("Ground", false);
				rigidbody2D.AddForce( new Vector2( 0, jumpForceAmount ));
			}
		}
	}

	//might want to make virtual or override to allow the 2 kinds of moves to be implemented
	//player and npc / AI
	protected virtual void Move(float movingSpeed){
	
	}

	public void Interact(){

	}

	protected void FlipPlayer(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
