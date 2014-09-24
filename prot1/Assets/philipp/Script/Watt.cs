using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Watt : MonoBehaviour 
{
	public float range = 5.0f;
	public float attackPower = 1.0f;
	public bool lightOn = false;
	public Light lightOnObj;
	public Light lightOffObj;

	public float creepMeleeRangeMin = 1.0f;
	public float creepMeleeRangeMax = 2.0f;
	public float speedReductionValue = 0.9f;
	public float rotationReductionValue = 0.9f;
	public float randomRotationValue = 100.0f;

	public float maxSpeed = 10.0f;
	public float rotateSpeed = 5.0f;

	List<GameObject> attackedCreeps = new List<GameObject>();
	List<GameObject> creepsAttackingInMelee = new List<GameObject>();

	// Use this for initialization
	void Start () 
	{
		SetLightOn(false);
	}

	public void AddCreepsAttackingInMelee(GameObject creepAttackingInMelee)
	{
		creepsAttackingInMelee.Add(creepAttackingInMelee);
	}

	public void RemoveCreepsAttackingInMelee(GameObject creepAttackingInMelee)
	{
		creepsAttackingInMelee.Remove(creepAttackingInMelee);
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			SetLightOn(!lightOn);
		}

		if (lightOn)
		{
			List<GameObject> creeps =  AttackLogic.GetTargetsInRange<Creep>(transform.position, range);
			int size = attackedCreeps.Count;
			for (int i = size - 1; i >= 0; --i)
			{
				GameObject outOfRange = attackedCreeps[i];
				if (!creeps.Contains(outOfRange))
				{
					StopAttack(outOfRange);
					attackedCreeps.Remove(outOfRange);
				}
			}
			foreach (GameObject creep in creeps)
			{
				if (!attackedCreeps.Contains(creep))
				{
					AttackedCreep(creep);
					attackedCreeps.Add(creep);
				}
			}
		}
		else
		{
			foreach (GameObject creep in attackedCreeps)
			{
				StopAttack(creep);
			}
			attackedCreeps.Clear();
		}
	}

	private void AttackedCreep(GameObject creep)
	{
		creep.GetComponentInChildren<LightningAttack>().SetAttackOn(true, attackPower);
	}

	private void StopAttack(GameObject creep)
	{
		creep.GetComponentInChildren<LightningAttack>().SetAttackOn(false, attackPower);
	}

	void SetLightOn(bool lo)
	{
		lightOn = lo;
		if (lightOn)
		{
			lightOnObj.enabled = true;
			lightOffObj.enabled = false;
		}
		else
		{
			lightOnObj.enabled = false;
			lightOffObj.enabled = true;
		}
	}

	// Update is called once per frame
	void FixedUpdate() 
	{
		CharacterController controller = GetComponent<CharacterController>();

		float damage = 0.0f;
		foreach (GameObject creep in creepsAttackingInMelee)
		{
			float distance = (creep.transform.position - transform.position).sqrMagnitude;
			if (distance < creepMeleeRangeMin)
			{
				damage += 1.0f;
			}
			else if (distance < creepMeleeRangeMax)
			{
				damage += (distance - creepMeleeRangeMin) / (creepMeleeRangeMax - creepMeleeRangeMin);
			}
		}

		if (damage > 1.0f)
		{
			damage =  1.0f;
		}

		float randomRot = (Random.value - 0.5f) * damage * randomRotationValue;
		transform.Rotate(0, randomRot, 0);

		float rotationReduction = 1.0f - damage * rotationReductionValue;
		if (Input.GetKey("d"))
		{
			transform.Rotate(0, rotateSpeed * rotationReduction, 0);
		}
		else if (Input.GetKey("a"))
		{
			transform.Rotate(0, -rotateSpeed * rotationReduction, 0);
		}

		float speedReduction = 1.0f - damage * speedReductionValue;		
		float curSpeed = 0;
		if (Input.GetKey("w"))
		{
			curSpeed = maxSpeed * speedReduction;
		}
		else if (Input.GetKey("s"))
		{
			curSpeed = -maxSpeed * speedReduction;
		}

		
		Vector3 forward = transform.TransformDirection(Vector3.forward);
		controller.SimpleMove(forward * curSpeed);	
	}
}
