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

    float enemySpeed;

    public bool CollisionWithPlayer= false;

    public bool playerTraced;
    void Start()
    {
        movementDirection = 1;
        enemySpeed = 1;
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
        PlayerTrace();
        headTrace();

        transform.Translate(movementDirection* enemySpeed*Time.deltaTime,0,0);

    }

    void leftWallTrace()
    {
        RaycastHit2D leftTrace =  Physics2D.Raycast(transform.position, Vector2.right, 1, groundMask);
        Debug.DrawRay(transform.position, Vector2.right* 1, Color.red);
        if(leftTrace.collider != null)
            movementDirection = -1;
    }

    void rightWallTrace()
    {
        RaycastHit2D rightTrace =  Physics2D.Raycast(transform.position, Vector2.right, -1, groundMask);
        Debug.DrawRay(transform.position, Vector2.right* -1, Color.red);
        if(rightTrace.collider != null)
            movementDirection = 1;
    }

    void headTrace()
    {
        RaycastHit2D TraceOnHead = Physics2D.Raycast(transform.position, Vector2.up, 1, playerMask);
        Debug.DrawRay(transform.position, Vector2.up*1, Color.yellow);
        if(TraceOnHead.collider != null && CollisionWithPlayer == true)
            Destroy(gameObject);
    }

    void PlayerTrace()
    {
        RaycastHit2D TracePlayer = Physics2D.Raycast(transform.position, Vector2.right, movementDirection*8, playerMask);
        Debug.DrawRay(transform.position, Vector2.right* movementDirection*8, Color.green);

        if(TracePlayer.collider != null)
        {
            enemySpeed = 2;
            movementDirection = playerRef.transform.position.y;
        }
            //movementDirection
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Player")
        {
            CollisionWithPlayer = true;
        }
    }

}
