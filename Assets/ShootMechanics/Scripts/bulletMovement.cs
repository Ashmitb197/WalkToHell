using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{

    protected int direction =10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        transform.Translate(Vector2.up*direction*Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if((col.collider != null) && (col.collider.tag != "Player") && (col.collider.tag != "Coins"))
        {
            Destroy(gameObject);
        }

    }

    public void updateDirection(int direction)
    {
        this.direction = direction;
    }
}
