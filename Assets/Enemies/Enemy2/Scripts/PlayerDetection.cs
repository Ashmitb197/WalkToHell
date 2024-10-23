using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public GameObject camRef;
    public GameObject player;
    public LayerMask playerLayer;


    public float fireRate;
    public float lastShot;

    public GameObject gunRef;
    public GameObject bulletPrefab;
    public bool isPlayerDetected;
    public bool isFacingRight;

    // Start is called before the first frame update
    void Start()
    {
        isPlayerDetected = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //playerRotation();
        tracePlayer();
        //checkRotation();
    }

    void tracePlayer()
    {
        Color colorofRay = Color.red;
        
        Debug.DrawRay(camRef.transform.position, camRef.transform.up*10, colorofRay);
        RaycastHit2D TracePlayer = Physics2D.Raycast(camRef.transform.position, -camRef.transform.up, camRef.transform.up.y*10, playerLayer);
       

        Vector2  playerDirection = player.transform.position - camRef.transform.position;
        Debug.Log("Player Direction: "+playerDirection.normalized);
        Vector2 playerDirectionNormalized = playerDirection.normalized; 

        if(TracePlayer.collider != null && TracePlayer.collider.tag == "Player")
        {
            isPlayerDetected = true;
            
            
            
            
            colorofRay = Color.green;
            
            bulletPrefab.GetComponent<bulletMovement>().fireSpeed = 1800;

            if(Time.time > lastShot+fireRate)
            {
                //Instantiate(bulletPrefab, camRef.transform.position, camRef.transform.rotation);
                lastShot = Time.time;
            }
            camRef.GetComponent<Animator>().speed = 0;

            
            
            
        }
        // else
        // {
        //     camRef.GetComponent<Animator>().speed = 1;
        // }


        
        if(isPlayerDetected)
        {
            camRef.transform.Rotate(new Vector3(0, 0, Mathf.Abs(playerDirectionNormalized.x * player.GetComponent<Rigidbody2D>().linearVelocity.x)));
        }
        Debug.Log("Player Velocity: "+player.GetComponent<Rigidbody2D>().linearVelocity.x);
    }

    // void playerRotation()
    // {

       
    //     if(!isPlayerDetected)
    //     {
    //         float rotationValue = 1;

            
    //         Vector3 rot = camRef.transform.eulerAngles;
    //         rot.z = Mathf.Clamp(rot.z, 115, 230);
    //         camRef.transform.eulerAngles = rot;

    //         if(isFacingRight)
    //         {
    //             rotationValue = -1;
    //         }
    //         if(!isFacingRight)
    //         {
                
    //             rotationValue = 1;
    //         }
            

    //         camRef.transform.Rotate(0,0,rotationValue);

    //     }
    // }

}
