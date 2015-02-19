using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TicTacToeRules : MonoBehaviour
{
		bool winCondition = false;
		GameData gameData;
	
		void Start ()
		{
				gameData = GetComponent<GameData> ();
		}

		void ShowWin (Vector3 combo)
		{
				foreach (Cell cell in gameData.cells.Values) {
						int cellPosition = cell.GetCellPosition ();
						if (cellPosition == combo.x || cellPosition == combo.y || cellPosition == combo.z) {
								cell.SetWin ();
						} else {
								cell.SetLose ();
						}
				}
		}
	
		public void CalcWin ()
		{
				foreach (Vector3 combo in gameData.combos) {
						CheckWin (combo, gameData.xCells);
						if (winCondition) {
								Debug.Log ("WIN X " + combo.ToString ());
								ShowWin (combo);
								SendMessage ("XWon");
								gameData.gameOver = true;
								return;
						}
						CheckWin (combo, gameData.oCells);
						if (winCondition) {
								Debug.Log ("WIN O " + combo.ToString ());
								ShowWin (combo);
								SendMessage ("OWon");
								gameData.gameOver = true;
								return;
						}
				}
				if (gameData.freeCells.Count == 0) {
						SendMessage ("Tie");
						gameData.gameOver = true;			
				}
		}
		
		void CheckWin (Vector3 combo, Dictionary<string, Cell> cells)
		{
				winCondition = false;
				bool xOk = false;
				bool yOk = false;
				bool zOk = false;
				foreach (Cell cell in cells.Values) {
						int cellPosition = cell.GetCellPosition ();
						if (cellPosition == combo.x)
								xOk = true;
						if (cellPosition == combo.y)
								yOk = true;
						if (cellPosition == combo.z)
								zOk = true;
				}
				if (xOk && yOk && zOk)
						winCondition = true;
		}
}
