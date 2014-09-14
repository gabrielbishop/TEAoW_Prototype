using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class SimplePatrol : MonoBehaviour 
{
	public Transform[] waypoints;
	public float threshhold = 0.5f;
	private NavMeshAgent agent;
	private uint currentPos = 0;

	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (waypoints.Length == 0)
			return;
		if (agent.hasPath)
		{
			if (agent.remainingDistance <= agent.stoppingDistance + threshhold)
			{
				currentPos = (currentPos + 1) % (uint)waypoints.Length;	
				agent.destination = waypoints[currentPos].position;
			}
		}
		else
		{
			agent.destination = waypoints[currentPos].position;
		}
	}
}
