using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float interpVelocity;
	public float minDistance;
	public float followDistance;
	public GameObject target;
	public Vector3 offset;
	Vector3 targetPos;
	// Use this for initialization
	void Start () {
		targetPos = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(target != null)
		{

			if(target.transform.position.y > 3)
			{
				offset.y = -0.1f;
			}
			else{
				offset.y = 0.1f;
			}
			if (target)
			{
				Vector3 posNoZ = transform.position;
				posNoZ.z = target.transform.position.z;

				Vector3 targetDirection = (target.transform.position - posNoZ);

				interpVelocity = targetDirection.magnitude * 5f;

				targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime); 

				transform.position = Vector3.Lerp( transform.position, targetPos + offset, 0.25f);
			}
			if(target.transform.position.x <= -21.74072)
			{
				offset.x = 0.5f;
			}

			else
			{
				offset.x = 0f;
			}
		}	
	}
}
