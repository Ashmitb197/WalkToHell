using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : HealthSystem
{

    public int enemyHealth;

    public AudioSource weaponSoundSource;
    public AudioClip swordStabClip;
    // Start is called before the first frame update
    void Start()
    {
        swordStabClip = Resources.Load("Weapons/Sword/SwordStab.mp3") as AudioClip;
        weaponSoundSource = GameObject.Find("Player").transform.Find("PivotPoint").gameObject.transform.Find("WeaponSound").gameObject.GetComponent<AudioSource>();
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
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Sword")
        {
            weaponSoundSource.PlayOneShot(swordStabClip, 0.5f);
            enemyHealth -= swordDamage;
        }
    }

}
