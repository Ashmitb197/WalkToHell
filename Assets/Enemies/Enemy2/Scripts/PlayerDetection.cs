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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tracePlayer();
    }

    void tracePlayer()
    {
        Color colorofRay = Color.red;
        Debug.DrawRay(camRef.transform.position, camRef.transform.up*10, colorofRay);

        RaycastHit2D TracePlayer = Physics2D.Raycast(camRef.transform.position, camRef.transform.up*10, playerLayer);

        if(TracePlayer.collider.tag == "Player")
        {
            
            camRef.GetComponent<Animator>().speed = 0;
            //colorofRay = Color.green;
            
            if(Time.time > lastShot+fireRate)
            {
                Instantiate(bulletPrefab, gunRef.transform.position, gunRef.transform.rotation);
                lastShot = Time.time;
            }

            
        }
        else 
        {
            camRef.GetComponent<Animator>().speed = 1;
        }


        
        // else if(TracePlayer == null) 
        // {
        //     camAnimator.speed = 2;
        // }
    }
}
