using UnityEngine;
using System.Collections;

public class MotionTest : MonoBehaviour {

	public float h = 5.0f;

	void FixedUpdate ()
	{
		if (Input.GetKey("d"))
		{
			rigidbody.AddTorque(transform.up * h);
		}
		else if (Input.GetKey("a"))
		{
			rigidbody.AddTorque(transform.up * -h);
		}
	}

}
