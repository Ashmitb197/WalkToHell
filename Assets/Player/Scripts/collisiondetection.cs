using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collisiondetection : MonoBehaviour {


	private float vertical;
	public Rigidbody2D rb;
	public bool isClimbing;

	public bool nearStairs;
	

	void Awake()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	public virtual void OnCollisionEnter2D(Collision2D coll)
	{
		
	}
	void Update()
	{

		vertical = Input.GetAxis("Vertical");

		if(nearStairs == true && Input.GetKey(KeyCode.W))
		{
			isClimbing = true;
		}


	}

	void FixedUpdate()
	{
		if(rb)
		{
			if(isClimbing)
			{
				rb.linearVelocity = new Vector2(0, vertical * 3);
			}
		// else
		// {
			
		// }
		}
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(rb)
		{

			if(col.tag == "Ladder")
			{
				nearStairs = true;
				
				rb.gravityScale = 0;
			
			}
		}	
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if(rb)
		{
			if(col.tag == "Ladder")
			{
				nearStairs = false;
				isClimbing = false;
				rb.gravityScale = 4;

			}
		}
	}

}
