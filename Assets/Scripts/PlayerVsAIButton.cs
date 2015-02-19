using UnityEngine;
using System.Collections;

public class PlayerVsAIButton : BaseButton
{

		void OnMouseUp ()
		{
				ticTacToe.SendMessage ("PlayerVsAI");
		}
}
