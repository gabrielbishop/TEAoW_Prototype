using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour 
{
	public Vector3 startPoint;
	public Vector3 endPoint;
	public float duration;
	public float height = 1.0f;
	public float gravity = 1.0f;

	private float timeSpent = 0.0f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate() 
	{
		timeSpent += Time.deltaTime;

		if (timeSpent < duration)
		{
			float alpha = timeSpent / duration;
			Vector3 pos = alpha * endPoint + (1.0f - alpha) * startPoint;
			pos.y += height * Mathf.Sin(Mathf.PI * alpha);
			transform.position = pos;
		}
		else
		{
			Vector3 pos = transform.position;
			pos.y -= gravity * Time.deltaTime;
			transform.position = pos;
		}
	}
}
