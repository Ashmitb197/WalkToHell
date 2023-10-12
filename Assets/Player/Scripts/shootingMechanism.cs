using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class shootingMechanism : MonoBehaviour
{

    public float lastShot;
    public float fireRate;


    public int maxAmmo;
    public int currentAmmo;
    public int magazine;

    public Text ammoText;
    // Start is called before the first frame update
    void Start()
    {
        fireRate = 0.2f;
        magazine = 3;
        maxAmmo =30;
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAmmo();
    }

    public void shootBullet(GameObject Gun, Rigidbody2D rb, GameObject bulletPrefab, GameObject muzzle)
	{
		bulletPrefab.GetComponent<Rigidbody2D>().velocity = bulletPrefab.transform.up * 140;
		if(Input.GetKey("e") && Time.time> lastShot+fireRate)
		{
            if(magazine >= 0 && maxAmmo > 2)
            {
            
                Instantiate(bulletPrefab, muzzle.transform.position , Gun.transform.rotation);
                rb.AddForce(-Gun.transform.up*2, ForceMode2D.Impulse);
                
                
                    if(currentAmmo >0)
                    {
                        currentAmmo--;
                    }
                    else if(currentAmmo == 0)
                    {
                        currentAmmo = maxAmmo;
                        magazine--;
                    }
                

                
                //if(bulletPrefab)
                lastShot = Time.time;
            }

			
            	
		}
		
	}

    public void UpdateAmmo()
    {
        ammoText.text = magazine + " | "+ currentAmmo;
    }
}
