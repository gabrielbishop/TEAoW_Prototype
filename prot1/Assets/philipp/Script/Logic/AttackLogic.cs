using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackLogic 
{
	public static List<GameObject> GetTargetsInRange<C>(Vector3 location, float radius) where C:Component
	{
		List<GameObject> targetsInRange = new List<GameObject>();

		Collider[] objectsInRange = Physics.OverlapSphere(location, radius);
		foreach (Collider col in objectsInRange)
		{
			if (col.GetComponent<C>() != null)
			{
				targetsInRange.Add(col.gameObject);
			}
		}
		return targetsInRange;
	}
}
