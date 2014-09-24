using UnityEngine;
using System.Collections;

[System.Serializable]
public class CreepFlee : com.teaow.fsm.FSMState
{	
	public float fleeSpeed = 10.0f;
	public Transform target;
	public float turnThreshhold = 0.1f;
	public float rotateSpeed = 0.1f;

	public CreepFlee()
	{
		name = "CreepFlee";
	}

	private GameObject owner;
	public void SetOwner(GameObject o)
	{
		owner = o;
	}
	
	public override void OnEnter()
	{
		base.OnEnter();
		NavMeshAgent agent = owner.GetComponent<NavMeshAgent>();	
		agent.enabled = false;
		owner.GetComponent<CharacterController>().enabled = true;
    }

    public override void Act()
	{
		Vector3 fleeDirection = owner.transform.position - target.position;
		fleeDirection.Normalize();
		//ownerBody.AddForce(fleeDirection * fleeSpeed);
		//ownerBody.AddTorque(fleeDirection);
		///ownerBody.velocity = ;
		CharacterController controller = owner.GetComponent<CharacterController>();
		Quaternion rotation = owner.transform.rotation; 
		rotation.SetLookRotation(fleeDirection); 
		owner.transform.rotation = rotation;

		controller.SimpleMove(fleeDirection * fleeSpeed);	
	}

	public override void OnLeave()
	{
		base.OnLeave();
		Rigidbody ownerBody = owner.rigidbody;
		ownerBody.velocity = Vector3.zero;
		owner.GetComponent<CharacterController>().enabled = false;
		NavMeshAgent agent = owner.GetComponent<NavMeshAgent>();	
		agent.enabled = true;
    }
    
}