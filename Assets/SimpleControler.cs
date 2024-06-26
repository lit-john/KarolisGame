﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleControler : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;
	bool Action;
	float move;
	Animator anim;
	Rigidbody2D rb;


	public float jumpforce = 700f;
	bool grounded = false;
	public Transform groundcheck;
	float groundRadious = 0.2f;
	public LayerMask whatIsGround;


	void Awake () {

		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}


	void FixedUpdate()
	{

		grounded = Physics2D.OverlapCircle(groundcheck.position, groundRadious, whatIsGround);
		anim.SetBool("Ground", grounded);

		anim.SetFloat("vspeed", rb.velocity.y);



		// if move is greater than 0 and we are not facing right flip.
		// else if move is less than 0 (moving in the negative direction - left) and we ARE facing right flip.
		if (move > 0 && !facingRight)
			Flip();
		else if (move < 0 && facingRight)
			Flip();


		move = Input.GetAxis("Horizontal");

		anim.SetFloat("Speed", Mathf.Abs(move));

		rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);



		Action = Input.GetButton("Fire1");

		if (Action == true)
		{
			anim.SetBool("Action", true);
		}
		else if (Action == false)
		{
			anim.SetBool("Action", false);
		}
	}


		void Update()
		{

			if (grounded && Input.GetButtonDown("Jump"))
			{
				anim.SetBool("Ground", false);
				rb.AddForce(new Vector2(0, jumpforce));
			}

		}

		void Flip()
		{
			//saying facingright is equal to not facingright (we are facing the oppisit direction)
			facingRight = !facingRight;
			//Get the local scale
			Vector3 theScale = transform.localScale;
			//flip the x axis
			theScale.x *= -1;
			//apply it back to the local scale
			transform.localScale = theScale;
			//all together taking the world and fliping it 180 degrees
		}

	
}
