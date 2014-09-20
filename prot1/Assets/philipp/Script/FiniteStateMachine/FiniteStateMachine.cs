using UnityEngine;
using System.Collections;

namespace com.teaow.fsm
{
	public class FiniteStateMachine : MonoBehaviour
	{
		private FSMState currentState = null;

		public void SetStartState(FSMState currentState)
		{
			this.currentState = currentState;
			this.currentState.OnEnter();
		}

		protected void UpdateImpl()
		{
			if (currentState != null)
			{
				FSMState nextState = currentState.Reason();
				if (nextState != null)
				{
					currentState.OnLeave();
					currentState = nextState;
					currentState.OnEnter();
				}
				currentState.Act();
			}
		}

		/// <summary>
		/// show state name on owner object
		/// </summary>
		/// <param name="owner">Owner.</param>
		public void ShowDebugInfo(GameObject owner)
		{
			currentState.ShowDebugInfo(owner);
		}
	}
}