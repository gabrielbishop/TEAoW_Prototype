using UnityEngine;
using System.Collections;

public class CreepBlackboard 
{
	private GameObject owner = null;
	private GameObject target = null;

	private float rangeToTarget = 0.0f;
	private bool inSight = false;
	private bool lightOn = false;
	private bool underAttack = false;

	public float GetRangeToTarget()
	{
		return rangeToTarget;
	}

	public bool IsInSight()
	{
		return inSight;
	}
	
	public bool IsLightOn()
	{
		return lightOn;
	}
	
	public bool IsUnderAttack()
	{
		return underAttack;
	}

	public void SetOwner(GameObject o)
	{
		owner = o;
	}	

	public GameObject GetOwner()
	{
		return owner;
	}	

	public void SetTarget(GameObject t)
	{
		target = t;
	}

	public void Update()
	{
		if ((target != null) && (owner != null))
		{
			Vector3 distance = owner.transform.position - target.transform.position;
			rangeToTarget = distance.magnitude;

			inSight = false;
			RaycastHit hit;
			if (Physics.Raycast(owner.transform.position, owner.transform.forward, out hit, 200))
			{
				if (hit.transform.gameObject == target)
				{
					inSight = true;
				}
			}

			lightOn = target.GetComponent<Watt>().lightOn;
			underAttack = owner.GetComponentInChildren<LightningAttack>().IsHit();
		}
	}
}
