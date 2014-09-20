using UnityEngine;
using System.Collections;
using com.teaow.fsm;
	
[System.Serializable]
public class TargetInRangeInSight : FSMTransition 
{
	public float range = 5.0f;

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
		if ((creepBlackboard.GetRangeToTarget() < range) && creepBlackboard.IsInSight())
		{
			return true;
		}
		return false;
	}
}