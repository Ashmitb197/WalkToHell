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
    public float lastShot;
    public float fireRate;

    public bool isTurnedRight;

    public GameObject gunRef;
    public GameObject bulletPrefab;

    void Start()
    {
        lastShot = 0.0f;
        fireRate = 1.5f;
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

    void PlayerTrace()
    {
        RaycastHit2D TracePlayer = Physics2D.Raycast(transform.position, Vector2.right, transform.right.x*8, playerMask);
        Debug.DrawRay(transform.position, Vector2.right* transform.right.x*8, Color.green);

        if(TracePlayer.collider != null)
        {
            enemySpeed = 0;
            if(Time.time > lastShot+fireRate)
            {
                StartCoroutine(shootBullet());
                lastShot = Time.time;
            }
        }
        else
        {
            enemySpeed = 1;
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

    void flipX(GameObject flippingObject)
    {
        isTurnedRight = !isTurnedRight;

        flippingObject.transform.Rotate(0, 180f, 0);
    }

    IEnumerator shootBullet()
    {
        
        Instantiate(bulletPrefab, gunRef.transform.position, gunRef.transform.rotation);
        yield return null;
       
    }

}
