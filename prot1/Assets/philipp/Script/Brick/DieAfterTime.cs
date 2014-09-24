using UnityEngine;
using System.Collections;

public class DieAfterTime : MonoBehaviour {

	public float timeToDeath = 1.0f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeToDeath -= Time.deltaTime;
		if (timeToDeath < 0.0f)
		{
			Destroy(gameObject);
		}
	}
}
