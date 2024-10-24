using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Movement_behaviour : MonoBehaviour {


	[Header("Movement Variables\n")]
	[SerializeField] private float moveSpeed = 2.0f;
	public float jumpforce = 20f;

	[Header("\nObject Refrences\n")]
	public Animator anime;
	public Rigidbody2D rb;
	public GameObject player;
	
	[SerializeField] private SpriteRenderer sr;
	[SerializeField] private LayerMask ground;

	public AudioSource source;
	public AudioClip clip;
	public LayerMask  foodLayer;
	public GameObject Gun;
	public GameObject bulletPrefab;
	public GameObject muzzleRefrence;

	[Header("\nOtherVariables\n")]
	public bool openMouth;

	public Transform feet;

	public shootingMechanism shootingMechanismScript;
	
	public float RayEndPoint;

	public bool isFacingLeft;
	

	public float HorizontalInput;

	public float mouseXInput;
	public float mouseYInput;
	public float rotationSpeed;	

	[Header("\nGun Variables")]
	public float lastShot;
	public float fireRate;
	public WeaponSelector weaponSelectScript;


	// Use this for initialization
	void Start () {

		Cursor.visible =false;
		Time.timeScale = 1;

		anime = gameObject.GetComponent<Animator>();
		rb = gameObject.GetComponent<Rigidbody2D>();
		sr = gameObject.GetComponent<SpriteRenderer>();
		
		isFacingLeft = true;
	}

	void Update()
	{
		
		HorizontalInput = Input.GetAxisRaw("Horizontal");

		mouseXInput = Input.GetAxis("Mouse X");
		mouseYInput = Input.GetAxis("Mouse Y");
		
		// Gun.transform.Rotate(new Vector3(0, 0, mouseYInput*rotationSpeed));

	}
	
	
	// Update is called once per frame
	void FixedUpdate () {
		walk();
		Jump();
		shootingMechanismScript.shootBullet(Gun, rb, bulletPrefab, muzzleRefrence);
		IsGrounded();
		//foodCheck();
		//gunControledRotation();

	}


	void gunControledRotation()
	{
		Vector3 rot = Gun.transform.rotation.eulerAngles + new Vector3(0, 0, mouseYInput*rotationSpeed);
        rot.z = Mathf.Clamp(rot.z, 240, 310f);

		Gun.transform.eulerAngles = rot;
	}

	void walk()
	{
		

		if(HorizontalInput != 0)
		{
			transform.Translate(moveSpeed*Time.deltaTime,0,0);
			anime.SetBool("Walking", true);
			if(HorizontalInput < 0 && isFacingLeft)
			{
				flip(gameObject);
				//flip(bulletPrefab);
			}
			else if(HorizontalInput > 0 && !isFacingLeft)
			{
				flip(gameObject);
				//flip(bulletPrefab);
			}

		}
		else{
			anime.SetBool("Walking", false);
		}
			

	}

	
	void Jump()
	{

		float jumpKeyPressedCheck = Input.GetAxisRaw("Jump");
		if(jumpKeyPressedCheck == 1 && IsGrounded())
		{
			Vector2 jump_movement = new Vector2(rb.linearVelocity.x, jumpforce);
			anime.SetBool("Jump", true);
			rb.linearVelocity = jump_movement;

			// if(sr.flipX == true)
			// {
			// 	sr.flipX = true;
			// }
			// else{
			// 	sr.flipX = false;
			// }
		}


		else{
			anime.SetBool("Jump", false);
			
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

	// void foodCheck()
	// {
		

	// 	Vector3 loweringRay = new Vector3(0,0.3f,0);
	// 	Color colorofRay = Color.red;

	// 	//Getting Player Direction
	// 	Vector2 playerDirectionForRay = Vector2.right;
	// 	RayEndPoint = 2*HorizontalInput;


	// 	Vector2 forward = transform.TransformDirection(Vector2.right) * 2;
	// 	//Vector3 loweringRay = new Vector3(0,0.3f,0);
	// 	RaycastHit2D foodCheckRay = Physics2D.Raycast(transform.position - loweringRay, playerDirectionForRay, RayEndPoint, foodLayer);
		
	// 	//Debug.Log(foodCheckRay.collider.tag);

	// 	if(foodCheckRay.collider != null)
	// 	{
	// 		colorofRay = Color.green;
	// 	}

	// 	Debug.DrawRay(transform.position - loweringRay, Vector2.right*RayEndPoint, colorofRay);

	// 	// if(foodCheckRay.collider.tag == "Coins")
	// 	// {
	// 	// 	openMouth = true;
	// 	// }

		
	// }

	void flip(GameObject flippingObject)
	{
		isFacingLeft = !isFacingLeft;
		flippingObject.transform.Rotate(0f,180f,0f);
	}

	public bool getIsFacingLeft()
    {
        return isFacingLeft;
    }

}
