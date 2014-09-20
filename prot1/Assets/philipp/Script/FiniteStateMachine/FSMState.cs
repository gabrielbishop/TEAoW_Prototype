using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace com.teaow.fsm
{
	public abstract class FSMState 
	{
		protected string name = "FSMState";
		public void ShowDebugInfo(GameObject owner)
		{
			Vector2 targetPos = Camera.main.WorldToScreenPoint(owner.transform.position);
			float widtht = 100.0f;
			float halfWidth = widtht * 0.5f;
			GUI.TextField(new Rect(targetPos.x - halfWidth, Screen.height - targetPos.y, widtht, 20.0f), name);
		}

		private Dictionary<FSMTransition, FSMState> transitionMap = new Dictionary<FSMTransition, FSMState>();

		/// <summary>
		/// Adds a state transition.
		/// </summary>
		/// <param name="transition">Transition.</param>
		/// <param name="state">State.</param>
		public void AddTransition(FSMTransition transition, FSMState state)
		{
			transitionMap.Add(transition,state);
		}

		/// <summary>
		/// Look for a possible transition
		/// first possible transition is returned
		/// </summary>
		public FSMState Reason()
		{
			foreach (KeyValuePair<FSMTransition, FSMState> entry in transitionMap)
			{
				if (entry.Key.Reason())
				{
					return entry.Value;
				}
			}
			return null;
		}

		/// <summary>
		/// executes the current active action
		/// </summary>
		public abstract void Act();

		/// <summary>
		/// execute on enter state
		/// </summary>
		public virtual void OnEnter()
		{
			foreach (KeyValuePair<FSMTransition, FSMState> entry in transitionMap)
			{
				entry.Key.OnEnter();
			}
		}

		/// <summary>
		/// execute on leave state
		/// </summary>
		public virtual void OnLeave()
		{
			
		}
	}
}