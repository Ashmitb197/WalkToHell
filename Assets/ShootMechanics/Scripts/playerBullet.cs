using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : bulletMovement
{

    public GameObject PlayerRef;
    public Rigidbody2D rb;
    public Movement_behaviour pMovementScript;

    [Range(500, 2000)] public int fireSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        PlayerRef = GameObject.Find("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        pMovementScript = PlayerRef.GetComponent<Movement_behaviour>();

        //rb.velocity = transform.right*fireSpeed*Time.deltaTime;
        fireSpeed = 700;

    }

    void Start()
    {
        if(pMovementScript.getIsFacingLeft() == true)
        {
            bulletBehaviour(rb, gameObject, -fireSpeed);
        }
        else
        {
            bulletBehaviour(rb, gameObject, fireSpeed);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        
        if(col.collider.tag != "Player")
        {
            Destroy(gameObject);
        }
        CollisionCheck(col);
        


    }

}
