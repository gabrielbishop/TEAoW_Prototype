using UnityEngine;
using System.Collections;
using com.teaow.fsm;

[System.Serializable]
public class HuntToFlee : FSMTransition 
{
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
		return creepBlackboard.IsUnderAttack();
	}
}