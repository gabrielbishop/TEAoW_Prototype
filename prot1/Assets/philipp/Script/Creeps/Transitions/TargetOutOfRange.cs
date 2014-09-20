using UnityEngine;
using System.Collections;
using com.teaow.fsm;

[System.Serializable]
public class TargetOutOfRange : FSMTransition 
{
	public float range = 10.0f;

	private CreepBlackboard creepBlackboard;
	public void SetCreepBlackboard(CreepBlackboard c)
	{
		creepBlackboard = c;
	}

	public void OnEnter()
	{ 
	}
	
	public bool Reason()
	{
		if (creepBlackboard.GetRangeToTarget() > range)
		{
			return true;
		}
		return false;
	}
}
