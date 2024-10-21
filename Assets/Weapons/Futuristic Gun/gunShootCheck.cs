using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunShootCheck : MonoBehaviour
{

    public bool isReadyToShoot;
    
    // Start is called before the first frame update
    void Start()
    {
        isReadyToShoot = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(isReadyToShoot)
        {
            gameObject.GetComponent<Animator>().speed  =0;
            //isReadyToShoot = false;
        }
        else
        {
            gameObject.GetComponent<Animator>().speed  =1;
        }
        
    }
}
