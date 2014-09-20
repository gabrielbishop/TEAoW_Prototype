using UnityEngine;
using System.Collections;
using com.teaow.fsm;

public class CreepFSM : FiniteStateMachine
{
	/// <summary>
	/// Creep states
	/// </summary>
	public CreepAttackMelee creepAttackMelee;
	public CreepAttackRanged creepAttackRanged;
	public CreepFlee creepFlee;
	public CreepHunt creepHunt;
	public CreepPatrol creepPatrol;

	/// <summary>
	/// creep state transitions
	/// </summary>
	public TimedTransition creepAttackMeleeDuration;
	public TimedTransition creepAttackRangedDuration;
	public TargetOutOfRange targetOutOfRange;
	public TargetInRangeInSight targetInRangeInSight;
	public FleeToPatrol fleeToPatrol;
	public HuntToAttackMelee huntToAttackMelee;
	public HuntToAttackRanged huntToAttackRanged;
	public HuntToFlee huntToFlee;

	public GameObject target;

	private CreepBlackboard creepBlackboard = new CreepBlackboard();

	void Start()
	{
		creepPatrol.SetOwner(gameObject);
		creepHunt.SetOwner(gameObject);

		creepBlackboard.SetOwner(gameObject);
		creepBlackboard.SetTarget(target);

		targetOutOfRange.SetCreepBlackboard(creepBlackboard);
		targetInRangeInSight.SetCreepBlackboard(creepBlackboard);
		fleeToPatrol.SetCreepBlackboard(creepBlackboard);
		huntToAttackMelee.SetCreepBlackboard(creepBlackboard);
		huntToAttackRanged.SetCreepBlackboard(creepBlackboard);
		huntToFlee.SetCreepBlackboard(creepBlackboard);


		creepPatrol.AddTransition(targetInRangeInSight, creepHunt);

		creepHunt.AddTransition(targetOutOfRange, creepPatrol);
		creepHunt.AddTransition(huntToAttackRanged, creepAttackRanged);
		creepHunt.AddTransition(huntToAttackMelee, creepAttackMelee);
		creepHunt.AddTransition(huntToFlee, creepFlee);

		creepAttackRanged.AddTransition(creepAttackRangedDuration, creepHunt);

		creepAttackRanged.AddTransition(creepAttackMeleeDuration, creepHunt);

		creepFlee.AddTransition(fleeToPatrol, creepPatrol);

		SetStartState(creepPatrol);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		creepBlackboard.Update();
		base.UpdateImpl();
	}

	void OnGUI()
	{
		ShowDebugInfo(creepBlackboard.GetOwner());
	}
}
