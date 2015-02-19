using UnityEngine;
using System.Collections;

public class PlayerVsPlayerButton : BaseButton
{

		void OnMouseUp ()
		{
				ticTacToe.SendMessage ("PlayerVsPlayer");
		}
}
