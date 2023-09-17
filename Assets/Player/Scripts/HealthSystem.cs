using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class damageData : collisiondetection
{
    public int gateDamage = 5;
    public int enemyDamage = 30;
}
public class HealthSystem :  damageData
{
    // Start is called before the first frame update

    public GameObject healthBar;

    public Slider healthSilder;

    public int maxHealth = 101;
    public int health = 100;


    void start()
    {
        healthBar = GameObject.Find("Canvas/HealthBar");
        healthSilder = healthBar.GetComponent<Slider>();
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Gate")
        {
            Debug.Log(health);
            health -= gateDamage;
        }

        

        if(col.collider.tag == "Enemy")
        {
            health -= enemyDamage;
        }

        healthSilder.value = health;


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Coins")
		{

			string collidername = col.name;
			Destroy(GameObject.Find(collidername));
            if(health < maxHealth)
			    health += 1;
			//scoret.GetComponent<Text>().text = score.ToString();

            Debug.Log(health);

		}
        
    }

}
