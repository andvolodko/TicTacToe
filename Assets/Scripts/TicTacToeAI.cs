using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Simple Tic Tac Toe AI script.
 * Idea get from http://code.tutsplus.com/tutorials/build-an-intelligent-tic-tac-toe-game-with-as3--active-3636
 * Made win combo if possible or block player if have win combination
 */
public class TicTacToeAI : MonoBehaviour
{
		private bool aiChoosed = false;
		private GameData gameData;
	
		void Start ()
		{
				gameData = GetComponent<GameData> ();
		}

		void GameStarted ()
		{
				if (gameData.modeAI && gameData.AIfirst) {
						StepAI ();
				}
		}

		public void StepAI ()
		{
				SendMessage("FreezeCells", true);
				Invoke ("AILogic", 1);
		}
	
		void AILogic ()
		{
				SendMessage("FreezeCells", false);
						
				aiChoosed = false;
				foreach (Cell cell in gameData.freeCells.Values) {
						if (!aiChoosed) {
								Dictionary<string, Cell> ocheck = new Dictionary<string, Cell> (gameData.oCells);
								ocheck.Add (cell.GetKey (), cell);
								if (CheckAIWin (ocheck))
										break;
						}
				}
		
				foreach (Cell cell in gameData.freeCells.Values) {
						if (!aiChoosed) {
								Dictionary<string, Cell> xcheck = new Dictionary<string, Cell> (gameData.xCells);
								xcheck.Add (cell.GetKey (), cell);
								if (CheckAIWin (xcheck))
										break;
						}
				}
				if (!aiChoosed) {
						int random = Random.Range (0, gameData.freeCells.Count - 1);
						int count = 0;
						foreach (Cell cell in gameData.freeCells.Values) {
								if (random == count) {
										clickOnCell (cell);
										break;
								}
								count++;
						}
						Debug.Log ("AI random cell");
				}

		}
		
		bool CheckAIWin (Dictionary<string, Cell> check)
		{
				foreach (Vector3 combo in gameData.combos) {
						bool xOk = false;
						bool yOk = false;
						bool zOk = false;
						foreach (Cell cell in check.Values) {
								int cellPosition = cell.GetCellPosition ();
								if (cellPosition == combo.x)
										xOk = true;
								if (cellPosition == combo.y)
										yOk = true;
								if (cellPosition == combo.z)
										zOk = true;
						}
						if (xOk && yOk && zOk) {
								// If there is a winning situation, choose the tile
								Debug.Log ("AI: Block or check winning tile");
								int last = check.Count - 1;
								int count = 0;
								foreach (Cell cell in check.Values) {
										if (last == count) {
												clickOnCell (cell);
												break;
										}
										count++;
								}
								aiChoosed = true; 
								break;
						}
				}
				return aiChoosed;
		}

		void clickOnCell (Cell cell)
		{
				if (!cell.IsFinished ()) {
						cell.AIClicked ();
				}
		}

}
