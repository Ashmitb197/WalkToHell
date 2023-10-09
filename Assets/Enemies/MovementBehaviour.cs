using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    
    // Start is called before the first frame update

    public LayerMask groundMask;

    public GameObject playerRef;

    public LayerMask playerMask;
    float movementDirection;

    public bool isTurnedRight;

    public float enemySpeed;

    public bool CollisionWithPlayer= false;

    public Rigidbody2D selfRigidBody;


    void Start()
    {
        selfRigidBody = gameObject.GetComponent<Rigidbody2D>();
        movementDirection = 1;
        enemySpeed = 100;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        leftRightMovement();
    }

    void leftRightMovement()
    {
        leftWallTrace();
        rightWallTrace();
        
        headTrace();

        //selfRigidBody.velocity  = Vector2.right* enemySpeed;
        transform.Translate(movementDirection* enemySpeed*Time.deltaTime,0,0);

    }

    void leftWallTrace()
    {
        RaycastHit2D leftTrace =  Physics2D.Raycast(transform.position, Vector2.right, 1, groundMask);
        Debug.DrawRay(transform.position, Vector2.right* 1, Color.red);
        if(leftTrace.collider != null)
            flipX(gameObject);
    }

    void rightWallTrace()
    {
        RaycastHit2D rightTrace =  Physics2D.Raycast(transform.position, Vector2.right, -1, groundMask);
        Debug.DrawRay(transform.position, Vector2.right* -1, Color.red);
        if(rightTrace.collider != null)
            flipX(gameObject);
    }

    void headTrace()
    {
        RaycastHit2D TraceOnHead = Physics2D.Raycast(transform.position, Vector2.up, 0.5f, playerMask);
        Debug.DrawRay(transform.position, Vector2.up*0.5f, Color.yellow);
        if(TraceOnHead.collider != null && CollisionWithPlayer == true)
            Destroy(gameObject);
    }

    

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Player")
        {
            CollisionWithPlayer = true;
        }
    }

    void flipX(GameObject flippingObject)
    {
        isTurnedRight = !isTurnedRight;

        flippingObject.transform.Rotate(0, 180f, 0);
    }

    

}
