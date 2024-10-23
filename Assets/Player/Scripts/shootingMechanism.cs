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

    public Animator anim;

    // public AudioClip shootSound;
    // public AudioSource weaponSoundSource;
    // public WeaponSelector weaponSelectScript;
    // public gunShootCheck futuristicGunShootCheckScript;
    // Start is called before the first frame update
    void Start()
    {

        //weaponSoundSource = gameObject.transform.Find("PivotPoint").gameObject.transform.Find("WeaponSound").gameObject.GetComponent<AudioSource>();
        
        anim = this.GetComponent<Animator>();
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
		bulletPrefab.GetComponent<Rigidbody2D>().linearVelocity = bulletPrefab.transform.up * 140;
		if(Input.GetKeyDown("e"))
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
                    //weaponSoundSource.PlayOneShot(shootSound, .5f);
                // else if(weaponSelectScript.futuristicSelected && futuristicGunShootCheckScript.isReadyToShoot)
                // {
                //     futuristicGunShootCheckScript.isReadyToShoot = false;
                //     Instantiate(bulletPrefab, muzzle.transform.position , Gun.transform.rotation);
                //     rb.AddForce(-Gun.transform.up*2, ForceMode2D.Impulse);
                    
                    
                    
                //         if(currentAmmo >0)
                //         {
                //             currentAmmo--;
                //         }
                //         else if(currentAmmo == 0)
                //         {
                //             currentAmmo = maxAmmo;
                //             magazine--;
                //         }
                //         weaponSoundSource.PlayOneShot(shootSound, .5f);
                    
                // }

                anim.SetBool("Shoot", true);

                
                //if(bulletPrefab)
               // lastShot = Time.time;
            }

            

            

			
            	
		}
		
	}

    public void UpdateAmmo()
    {
        ammoText.text = magazine + " | "+ currentAmmo;
    }

    public void UpdateShootState()
    {
        anim.SetBool("Shoot", false);
    }
}
