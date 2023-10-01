using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthScript : HealthSystem
{

    public int playerHealth;
    public GameObject healthBar;

    public Slider healthSilder;

    public GameObject gameOverCanvas;

    public bool isDead;

    public int graveType;
    public GameObject[] gravePrefab;



    // Start is called before the first frame update
    void start()
    {
        
        

        healthBar = GameObject.Find("Canvas/HealthBar");
        healthSilder = healthBar.GetComponent<Slider>();
        gameOverCanvas = GameObject.Find("GameOverCanvas");

        gameOverCanvas.SetActive(false);

        

        
    }

    void Awake()
    {
        
        playerHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthSilder.value = playerHealth;
       
        
        DeathCheck();

        
    }


    void DeathCheck()
    {

        graveType = Random.Range(0,2);
        Vector3 graveAddOffset = new Vector3(0,-0.3f,0);
        
        if(playerHealth < 1)
        {
            isDead = true;
            Instantiate(gravePrefab[graveType], transform.position+graveAddOffset, transform.rotation);

        }
        else
        {
            isDead = false;
        }
        die(isDead);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Gate")
        {
           
            playerHealth -= gateDamage;
            Debug.Log(playerHealth);
        }

        

        if(col.collider.tag == "Enemy")
        {
            playerHealth -= enemyDamage;
        }

        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Coins")
		{

			string collidername = col.name;
			Destroy(GameObject.Find(collidername));
            if(playerHealth < maxHealth)
			    playerHealth += 1;
			//scoret.GetComponent<Text>().text = score.ToString();

            Debug.Log(playerHealth);

		}
        
    }


}
