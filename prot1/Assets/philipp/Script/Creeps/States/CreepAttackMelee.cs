using UnityEngine;
using System.Collections;

[System.Serializable]
public class CreepAttackMelee : com.teaow.fsm.FSMState
{	
	public float rotateSpeed = 20.0f;
	public Transform target;
	public float threshhold = 0.5f;
	public float newPathDistance = 2.0f;
	private NavMeshAgent agent;
	private Vector3 oldDestination = Vector3.zero;

	public CreepAttackMelee()
	{
		name = "CreepAttackMelee";
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
		agent.destination = target.position;
		target.GetComponent<Watt>().AddCreepsAttackingInMelee(owner);
	}

	public override void Act()
	{
		owner.transform.Rotate(0.0f, rotateSpeed, 0.0f);
		NewPath(target.position);	
	}

	public override void OnLeave()
	{
		base.OnLeave();
		agent.Stop();
		target.GetComponent<Watt>().RemoveCreepsAttackingInMelee(owner);
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
