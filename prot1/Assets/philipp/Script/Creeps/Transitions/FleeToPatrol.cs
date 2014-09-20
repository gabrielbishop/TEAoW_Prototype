using UnityEngine;
using System.Collections;
using com.teaow.fsm;

[System.Serializable]
public class FleeToPatrol : FSMTransition 
{
	public float duration = 5.0f;
	float timeElapsed = 0.0f;

	private CreepBlackboard creepBlackboard;
	public void SetCreepBlackboard(CreepBlackboard c)
	{
		creepBlackboard = c;
	}
	
	public void OnEnter()
	{ 
		timeElapsed = 0.0f;
	}
	
	public bool Reason()
	{
		if (!creepBlackboard.IsUnderAttack())
		{
			timeElapsed += Time.deltaTime;
			if (timeElapsed >= duration)
			{
				return true;
			}
		}
		else
		{
			timeElapsed = 0.0f;
		}
		return false;
	}
}