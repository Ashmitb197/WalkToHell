using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagment : MonoBehaviour
{

    public GameObject player;
    public GameObject gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {  
        if(player == null)
        {

            Invoke("activateGameOverCanvas", 3);
            Cursor.visible = true;
        }
        
    }


    void activateGameOverCanvas()
    {
        gameOverCanvas.SetActive(true);
    }
}
