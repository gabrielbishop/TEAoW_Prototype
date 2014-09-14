using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class SimpleCharacter : MonoBehaviour 
{
	public float maxSpeed = 10.0f;
	public float rotateSpeed = 5.0f;
	
	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		CharacterController controller = GetComponent<CharacterController>();

		if (Input.GetKey("d"))
		{
			transform.Rotate(0, rotateSpeed, 0);
		}
		else if (Input.GetKey("a"))
		{
			transform.Rotate(0, -rotateSpeed, 0);
		}

		float curSpeed = 0;
		if (Input.GetKey("w"))
		{
			curSpeed = maxSpeed;
		}
		else if (Input.GetKey("s"))
		{
			curSpeed = -maxSpeed;
		}

		Vector3 forward = transform.TransformDirection(Vector3.forward);
		controller.SimpleMove(forward * curSpeed);	
	}
}
