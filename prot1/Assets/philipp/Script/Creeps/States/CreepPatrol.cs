using UnityEngine;
using System.Collections;

[System.Serializable]
public class CreepPatrol : com.teaow.fsm.FSMState
{
	public Transform[] waypoints;
	public float threshhold = 0.5f;
	private NavMeshAgent agent;
	private uint currentPos = 0;

	public CreepPatrol()
	{
		name = "CreepPatrol";
	}

	private GameObject owner;
	public void SetOwner(GameObject o)
	{
		owner = o;
	}

	public override void OnEnter()
	{
		base.OnEnter();
		agent = owner.GetComponent<NavMeshAgent>();	
	}

	public override void Act()
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

	public override void OnLeave()
	{
		base.OnLeave();
		agent.Stop();
	}
}
