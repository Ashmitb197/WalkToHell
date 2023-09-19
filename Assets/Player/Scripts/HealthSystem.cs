using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class damageData : collisiondetection
{
    public int gateDamage = 5;
    public int enemyDamage = 30;
    public int fallDamage = 4;    //TO DO

}
public class HealthSystem :  damageData
{
    // Start is called before the first frame update

   

    public int maxHealth = 100;
    public int health = 100;



    

    void update()
    {


    }

    public virtual void die(bool isDead)
    {
        if(isDead)
        {
            Destroy(gameObject);

        }

    }


    

}
