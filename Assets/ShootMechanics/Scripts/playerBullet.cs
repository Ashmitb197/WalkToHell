using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : bulletMovement
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            updateDirection(10);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            updateDirection(-10);
        }

    }
}
