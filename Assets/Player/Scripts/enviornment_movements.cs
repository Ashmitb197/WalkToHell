using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enviornment_movements : MonoBehaviour {
	
	public GameObject clds;
	public float speed_clds;
	public Vector2 mclds;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		clds_movement();
		
	}


	void clds_movement()
	{
		speed_clds = -0.5f;
		mclds = new Vector2(speed_clds,0);
		clds.transform.Translate(mclds*Time.deltaTime);
		if(clds.transform.position.x <=-39.2f)
		{
			clds.transform.Translate(90f,0,0);
		}

	}
}
