using UnityEngine;
using System.Collections;

public class PositionHealthbar : MonoBehaviour 
{

	public Transform target;

	// Update is called once per frame
	void Update () 
	{
		transform.position = Camera.main.WorldToViewportPoint(target.position);
	}
}
