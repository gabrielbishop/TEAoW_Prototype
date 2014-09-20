using UnityEngine;
using System.Collections;
using com.teaow.fsm;

[System.Serializable]
public class HuntToAttackRanged : FSMTransition 
{
	public float range = 7.0f;
	
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
		if ((creepBlackboard.GetRangeToTarget() < range) && creepBlackboard.IsInSight() && creepBlackboard.IsLightOn())
		{
			return true;
		}
		return false;
	}
}