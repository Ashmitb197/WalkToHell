using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    [Range(500, 2000)] public int fireSpeed;

   void Awake()
   {

        //rb = gameObject.GetComponent<Rigidbody2D>();

        //rb.velocity = transform.right*fireSpeed*Time.deltaTime;
        fireSpeed = 1800;
   }

   void Start()
   {
        gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.transform.up * 140;//*Time.deltaTime;
   }
    


    void OnCollisionEnter2D(Collision2D col)
    {
        if((col.collider != null) && (col.collider.tag != "Bullet"))
        {
            Destroy(gameObject);
        }



    }
}
