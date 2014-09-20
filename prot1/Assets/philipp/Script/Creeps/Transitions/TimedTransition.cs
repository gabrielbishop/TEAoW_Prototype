using UnityEngine;
using System.Collections;
using com.teaow.fsm;

[System.Serializable]
public class TimedTransition : FSMTransition 
{
	public float duration = 5.0f;
	float timeElapsed = 0.0f;

	public void OnEnter()
	{
		timeElapsed = 0.0f;
	}

	public bool Reason()
	{
		timeElapsed += Time.deltaTime;
		if (timeElapsed >= duration)
		{
			return true;
		}
		return false;
	}
}
