using UnityEngine;
using System.Collections;

[RequireComponent(typeof(HealthBar))]
public class Creep : MonoBehaviour 
{
	public float totalLifeEnergy = 20.0f;

	float damageTaken = 0.0f;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float healthInPercent = Mathf.Max(0.0f, 1.0f - damageTaken / totalLifeEnergy);
		GetComponent<HealthBar>().healthInPercent = healthInPercent;

	}

	public void Damage(float damage)
	{
		damageTaken += damage;
	}
}
