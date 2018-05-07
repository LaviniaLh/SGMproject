using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;

	public KeyCode left;
	public KeyCode right;
	public KeyCode jump;
	public KeyCode throwBall;
	private Rigidbody2D theRB;

	public Transform groundCheckPoint;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public bool isGrounded;

	private Animator anim;

	public  GameObject gem;

	public Transform throwPoint;

	public AudioSource throwSound;

	void Start () {
		theRB = GetComponent<Rigidbody2D>();

		anim = GetComponent<Animator>();
	}
	
	
	void Update () {

		isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

		if(Input.GetKey(left))
		{
			theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
			 
		}	else if(Input.GetKey(right))
		{
			theRB.velocity = new Vector2 (moveSpeed, theRB.velocity.y);
		} else
		{
			theRB.velocity = new Vector2 (0, theRB.velocity.y);
		}

		if(Input.GetKeyDown(jump) && isGrounded)
		{
			theRB.velocity = new Vector2 (theRB.velocity.x, jumpForce);
		}
		
		if(Input.GetKeyDown(throwBall))
		{
			GameObject gemClone = (GameObject)Instantiate(gem, throwPoint.position, throwPoint.rotation);
			gemClone.transform.localScale = transform.localScale;
		
			anim.SetTrigger("Throw");

			throwSound.Play();
		}

		if(theRB.velocity.x<0)
		{
			transform.localScale = new Vector3(-1,1,1)*0.5f;
		} else if(theRB.velocity.x>0)
		{
			transform.localScale = new Vector3(1,1,1)*0.5f;
		}
		anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
		anim.SetBool("Grounded", isGrounded);
	}
}
