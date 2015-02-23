using UnityEngine;
using System.Collections;

public class OnlineGameButton : BaseButton {

	void OnMouseUp ()
	{
		ticTacToe.SendMessage ("OnlineGame");
	}
}
