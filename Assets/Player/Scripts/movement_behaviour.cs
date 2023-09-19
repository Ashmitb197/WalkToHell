using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class movement_behaviour : MonoBehaviour {

	public Animator anime;
	public Rigidbody2D rb;
	public GameObject player;
	[SerializeField] private Vector2 move;
	[SerializeField] private float right = 2.0f;
	[SerializeField] private SpriteRenderer sr;
	[SerializeField] private LayerMask ground;
	public Transform feet;
	public float jumpforce = 20f;

	public GameObject clouds;
	public AudioSource source;
	public AudioClip clip;

	public bool openMouth;

	public LayerMask  foodLayer;
	
	public int RayEndPoint;

	public GameObject Gun;

	public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {

		//anime = GameObject.GetComponent<Animator>();
		//rb = GameObject.GetComponent<Rigidbody2D>();
		
	}


	
	
	// Update is called once per frame
	void Update () {
		walk();
		Jump();
		shootBullet();
		IsGrounded();
		Bug_fix();
		foodCheck();

	}



	void walk()
	{
		
		move = new Vector2(right,0f);
		if (Input.GetKey("d"))
		{
			anime.SetBool("Walking", true);
			player.transform.Translate(move*Time.deltaTime);
			sr.flipX = true;
			//source.Play(clip);
		}
		else if(Input.GetKey("a"))
		{
			anime.SetBool("Walking", true);
			player.transform.Translate(-move*Time.deltaTime);
			sr.flipX = false;
		}
		else
		{
			anime.SetBool("Walking", false);
		}

	}
	void Jump()
	{
		if(Input.GetKeyDown("space") && IsGrounded())
		{
			Vector2 jump_movement = new Vector2(rb.velocity.x, jumpforce);
			anime.SetBool("Jump", true);
			rb.velocity = jump_movement;

			if(sr.flipX == true)
			{
				sr.flipX = true;
			}
			else{
				sr.flipX = false;
			}
		}


		else{
			anime.SetBool("Jump", false);
			
		}
	}

	void shootBullet()
	{
		if(Input.GetKeyDown(KeyCode.E))
		{
			Instantiate(bulletPrefab, Gun.transform.position, bulletPrefab.transform.rotation);
		}
	}

	public bool IsGrounded()
	{
		Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, ground);
		if(groundCheck != null)
		{
			return true;
		}
		return false;
	}

	void Bug_fix()
	{
		if(player.transform.rotation.z <= 10)
		{
			Vector2 rot_angle = new Vector2(0,0);
			player.transform.eulerAngles = rot_angle;
		}
		if(player.transform.rotation.z <= 10)
		{
			Vector2 rot_angle = new Vector2(0,0);
			player.transform.eulerAngles = rot_angle;
		}


	}

	void foodCheck()
	{
		

		Vector3 loweringRay = new Vector3(0,0.3f,0);
		Color colorofRay = Color.red;

		//Getting Player Direction
		Vector2 playerDirectionForRay = Vector2.right;
		if(Input.GetKey(KeyCode.A))
		{
			RayEndPoint = -2;
		}
		else if (Input.GetKey(KeyCode.D))
		{
			RayEndPoint = 2;
		}


		Vector2 forward = transform.TransformDirection(Vector2.right) * 2;
		//Vector3 loweringRay = new Vector3(0,0.3f,0);
		RaycastHit2D foodCheckRay = Physics2D.Raycast(transform.position - loweringRay, playerDirectionForRay, RayEndPoint, foodLayer);
		
		//Debug.Log(foodCheckRay.collider.tag);

		if(foodCheckRay.collider != null)
		{
			colorofRay = Color.green;
		}

		Debug.DrawRay(transform.position - loweringRay, Vector2.right*RayEndPoint, colorofRay);

		// if(foodCheckRay.collider.tag == "Coins")
		// {
		// 	openMouth = true;
		// }
	}


}
