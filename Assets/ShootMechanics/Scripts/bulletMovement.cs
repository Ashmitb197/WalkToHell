using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{

    protected int direction;

    public GameObject PlayerRef;
    public Rigidbody2D rb;
    public Movement_behaviour pMovementScript;

    [Range(500, 2000)] public int fireSpeed;

   void Awake()
   {
        PlayerRef = GameObject.Find("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        pMovementScript = PlayerRef.GetComponent<Movement_behaviour>();

        //rb.velocity = transform.right*fireSpeed*Time.deltaTime;
        fireSpeed = 10;
   }

   void Start()
   {
        rb.velocity = transform.up*fireSpeed;//*Time.deltaTime;
   }
    


    void OnCollisionEnter2D(Collision2D col)
    {
        if((col.collider != null) && (col.collider.tag != "Bullet"))
        {
            Destroy(gameObject);
        }



    }
}
