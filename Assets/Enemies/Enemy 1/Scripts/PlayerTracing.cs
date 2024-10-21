using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracing : MonoBehaviour
{
    public bool playerTraced;
    public float lastShot;
    public float fireRate;

    

    public GameObject gunRef;
    public GameObject bulletPrefab;

    public MovementBehaviour enemyMovementScript;

    // Start is called before the first frame update
    void Start()
    {

        gunRef = gameObject.transform.GetChild(0).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerTrace();
    }


    void PlayerTrace()
    {
        RaycastHit2D TracePlayer = Physics2D.Raycast(transform.position, Vector2.right, transform.right.x*8, enemyMovementScript.Masks[0]);
        Debug.DrawRay(transform.position, Vector2.right* transform.right.x*8, Color.green);

        if(TracePlayer.collider != null)
        {
            enemyMovementScript.enemySpeed = 0;
            if(Time.time > lastShot+fireRate)
            {
                
                StartCoroutine(shootBullet());
                
                lastShot = Time.time;
            }
        }
        else
        {
            Time.timeScale = 1f;
            enemyMovementScript.enemySpeed = 1;
        }
            //movementDirection
    }

    IEnumerator shootBullet()
    {

        
        
        Instantiate(bulletPrefab, gunRef.transform.GetChild(0).gameObject.transform.position, gunRef.transform.rotation);
        Time.timeScale = 0.1f;
        yield return null;
       
    }

}
