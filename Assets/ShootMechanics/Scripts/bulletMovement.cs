using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{

    protected int direction;

    public float fireSpeed;

   
    // Start is called before the first frame update
    void Start()
    {
        fireSpeed = 8;
    }

    // Update is called once per frame
    public void bulletBehaviour(Rigidbody2D bulletrigidBody, GameObject self)
    {
        bulletrigidBody.velocity = self.transform.right*fireSpeed*Time.deltaTime;
    }

    protected void CollisionCheck(Collision2D col)
    {
        if((col.collider != null) && (col.collider.tag != "Coins"))
        {
            Destroy(gameObject);
        }

    }

    public void updateDirection(int direction)
    {
        this.direction = direction;
    }
}
