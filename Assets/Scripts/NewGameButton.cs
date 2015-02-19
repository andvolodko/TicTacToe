using UnityEngine;
using System.Collections;

public class NewGameButton : BaseButton
{

		void OnMouseUp ()
		{
				ticTacToe.SendMessage ("NewGame");
		}
}
