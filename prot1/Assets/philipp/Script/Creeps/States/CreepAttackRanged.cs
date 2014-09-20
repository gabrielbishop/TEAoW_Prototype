using UnityEngine;
using System.Collections;

[System.Serializable]
public class CreepAttackRanged : com.teaow.fsm.FSMState
{
	private GameObject owner;
	public void SetOwner(GameObject o)
	{
		owner = o;
	}

	public CreepAttackRanged()
	{
		name = "CreepAttackRanged";
	}

	public override void Act()
	{
		
	}
	
}