using UnityEngine;
using System.Collections;

[System.Serializable]
public class CreepAttackMelee : com.teaow.fsm.FSMState
{	
	public CreepAttackMelee()
	{
		name = "CreepAttackMelee";
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
