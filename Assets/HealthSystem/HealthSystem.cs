using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class damageData : collisiondetection
{
    public int gateDamage = 5;
    public int enemyDamage = 30;
    public int fallDamage = 4;    //TO DO
    public int bulletDamage = 37;

}
public class HealthSystem :  damageData
{
    // Start is called before the first frame update

   

    public int maxHealth = 100;

    //Randmomizing the bulletDamage value so the bullet damage doesn't apply same to all
    public void automateBulletDamage()
    {
        bulletDamage = Random.Range(37, 48);
        Debug.Log(bulletDamage);
    }


    

    public void die(bool isDead)
    {
        if(isDead)
        {
            Destroy(gameObject);

        }

    }


    

}
