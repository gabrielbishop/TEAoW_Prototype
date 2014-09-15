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

	List<GameObject> attackedCreeps = new List<GameObject>();

	// Use this for initialization
	void Start () 
	{
		SetLightOn(false);
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
}
