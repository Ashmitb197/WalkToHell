using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{

    protected int direction;

   
    

    // Update is called once per frame
    public void bulletBehaviour(Rigidbody2D bulletrigidBody, GameObject self, int fireSpeed)
    {

        bulletrigidBody.velocity = self.transform.up*fireSpeed*Time.deltaTime;
    }

    protected void CollisionCheck(Collision2D col)
    {
        if((col.collider != null) && (col.collider.tag != "Coins"))
        {
            Destroy(gameObject);
        }

    }
}
