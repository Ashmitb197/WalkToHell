using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : HealthSystem
{

    public int enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        enemyHealth = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        if(enemyHealth<1)
        {
            die(true);
        }

        automateBulletDamage();
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Bullet")
        {
            enemyHealth -= bulletDamage;
        }
    }
}
