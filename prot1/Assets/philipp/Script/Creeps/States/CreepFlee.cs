using UnityEngine;
using System.Collections;

[System.Serializable]
public class CreepFlee : com.teaow.fsm.FSMState
{	
	public CreepFlee()
	{
		name = "CreepFlee";
	}

	private GameObject owner;
	public void SetOwner(GameObject o)
	{
		owner = o;
	}

	public override void Act()
	{
		
	}
	
}