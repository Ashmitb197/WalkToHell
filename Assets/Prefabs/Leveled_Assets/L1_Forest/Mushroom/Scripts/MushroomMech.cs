using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMech : MonoBehaviour
{

    public LayerMask playerLayerMask;
    public Animator mushroomAnim;

    public GameObject playerRef;
    // Start is called before the first frame update
    void Start()
    {

        mushroomAnim = gameObject.GetComponent<Animator>();
        playerRef = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        playerTracing();
    }

    void playerTracing()
    {
        Debug.DrawRay(transform.position, (Vector2.zero + new Vector2(0, 0.5f))*1.5f, Color.green);

        RaycastHit2D tracePlayerRay = Physics2D.Raycast(transform.position, (Vector2.zero + new Vector2(0, 0.5f)), 1f, playerLayerMask);

        if(tracePlayerRay.collider != null)
        {
            mushroomAnim.SetBool("isPlayerOnTop", true);
            if(playerRef)
            {
                playerRef.GetComponent<Rigidbody2D>().AddForce(new Vector3(0,3,0), ForceMode2D.Impulse);
            }
        }
        else{
            mushroomAnim.SetBool("isPlayerOnTop", false);
        }
    }
}