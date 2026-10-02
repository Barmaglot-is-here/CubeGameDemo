using System;

namespace GameCycleManagement
{

	[Serializable]
	public class InvalidTransitionException : Exception
	{
		public InvalidTransitionException(string currentState, string nextState) 
			: base($"Current state: {currentState}, Next state: {nextState}") { }
	}   
}