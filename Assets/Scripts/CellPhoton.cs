using UnityEngine;
using System.Collections;

public class CellPhoton :  MonoBehaviour  {

	Cell cell;

	GameObject ticTacToe;

	TicTacToePhoton ticTacToePhoton;

	GameData gameData;

	void Start ()
	{
		gameData = GetComponent<GameData> ();
		cell = GetComponent<Cell> ();
		ticTacToe = GameObject.Find ("TicTacToe");
		ticTacToePhoton = ticTacToe.GetComponent<TicTacToePhoton> ();
	}
		
	void cellClicked ()
	{
		if (PhotonNetwork.connected && PhotonNetwork.inRoom) {
			ticTacToePhoton.photonView.RPC("CellRPC", PhotonTargets.All, cell.GetKey());
		}
	}


}
