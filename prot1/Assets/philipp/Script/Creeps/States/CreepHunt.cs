using UnityEngine;
using System.Collections;

[System.Serializable]
public class CreepHunt : com.teaow.fsm.FSMState
{
	public Transform target;
	public float threshhold = 0.5f;
	public float newPathDistance = 2.0f;
	private NavMeshAgent agent;
	
	public CreepHunt()
	{
		name = "CreepHunt";
	}

	private GameObject owner;
	public void SetOwner(GameObject o)
	{
		owner = o;
	}

	private Vector3 oldDestination = Vector3.zero;
	
	public override void OnEnter()
	{
		base.OnEnter();
		agent = owner.GetComponent<NavMeshAgent>();	
		agent.destination = target.position;
	}
	
	public override void Act()
	{
		NewPath(target.position);	
	}

	public override void OnLeave()
	{
		base.OnLeave();
		agent.Stop();
	}

	private void NewPath(Vector3 destination)
	{
		/// only calculate new path if old destination to far away from new destination
		if (agent.hasPath && (oldDestination != Vector3.zero) && (oldDestination - destination).sqrMagnitude < newPathDistance)
		{
			return;
		}

		oldDestination = destination;
		agent.destination = destination;
	}
}
