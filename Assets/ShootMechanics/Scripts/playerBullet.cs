using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : bulletMovement
{

    public GameObject PlayerRef;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRef = GameObject.Find("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();

        //rb.velocity = transform.right*fireSpeed*Time.deltaTime;
        bulletBehaviour(rb, gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        // if(playerSpriteRenderer.flipX == false)
        // {
        //     updateDirection(10);
        // }
        // else if(playerSpriteRenderer.flipX == true)
        // {
        //     updateDirection(-10);
        // }

       // bulletBehaviour(PlayerRef);

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
