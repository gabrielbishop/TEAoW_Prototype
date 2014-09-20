using UnityEngine;
using System.Collections;

namespace com.teaow.fsm
{

	public interface FSMTransition
	{
		void OnEnter();
		bool Reason();
	}

}