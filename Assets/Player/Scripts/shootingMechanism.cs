using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingMechanism : MonoBehaviour
{

    float lastShot;
    float fireRate =1 ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shootBullet(GameObject Gun, Rigidbody2D rb, GameObject bulletPrefab)
	{
		bulletPrefab.GetComponent<Rigidbody2D> ().velocity = bulletPrefab.transform.up * 140;
		if(Input.GetKey("e") && Time.time> lastShot+fireRate)
		{
			Instantiate(bulletPrefab, Gun.transform.position , Gun.transform.rotation);
			//if(bulletPrefab)
			lastShot = Time.time;

			rb.AddForce(-Gun.transform.up*4, ForceMode2D.Impulse);
            	
		}
		
	}
}
