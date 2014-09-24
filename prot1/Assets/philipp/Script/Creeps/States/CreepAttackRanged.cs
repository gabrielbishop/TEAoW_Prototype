using UnityEngine;
using System.Collections;

[System.Serializable]
public class CreepAttackRanged : com.teaow.fsm.FSMState
{	
	public GameObject target;
	public float brickSpeed;
	public GameObject brickPrefab;
	
	public CreepAttackRanged()
	{
		name = "CreepAttackRanged";
	}

	private GameObject owner;
	public void SetOwner(GameObject o)
	{
		owner = o;
	}

	public override void OnEnter()
	{
		base.OnEnter();

		Vector3 playerPos = target.transform.position;
		Vector3 creepPos = owner.transform.position;

		CharacterController playerController = target.GetComponent<CharacterController>();
		Vector3 playerDirection = playerController.velocity;
		float playerSpeed = playerDirection.magnitude;

		/// player stopped
		if (playerSpeed == 0.0f)
		{
			Vector3 hitPos = playerPos;
			Vector3 hitVector = hitPos - creepPos;
			float hitTime = hitVector.magnitude / brickSpeed;
			SpawnBrick(hitPos, hitTime);
		}
		else
		{
			playerDirection /= playerSpeed;

			Vector3 playerToCreep = creepPos - playerPos;
			float playerToCreepDistance = playerToCreep.magnitude;
			playerToCreep /= playerToCreepDistance;
			float omega = Mathf.Acos(Vector3.Dot(playerToCreep,playerDirection));
			float alpha = Mathf.Asin(playerSpeed * Mathf.Sin(omega) / brickSpeed) ;
			float beta = Mathf.PI - omega - alpha;
			float hitDistance = playerToCreepDistance * Mathf.Sin(omega) / Mathf.Sin(beta);
			float hitTime = hitDistance / brickSpeed;
			Vector3 hitPos = target.transform.position + playerDirection * playerSpeed * hitTime;
			SpawnBrick(hitPos, hitTime);
		}

	}

	private void SpawnBrick(Vector3 hitPos, float hitTime)
	{
		Creep creep = owner.GetComponent<Creep>();
		GameObject brickObject = creep.Spawn(brickPrefab);
		Fly fly = brickObject.GetComponent<Fly>();
		fly.duration = hitTime;
		fly.startPoint = owner.transform.position;
		fly.endPoint = hitPos;
	}

	public override void Act()
	{
		
	}
	
}