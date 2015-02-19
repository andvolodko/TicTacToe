using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TicTacToeMain : MonoBehaviour
{
		public GameObject cellTemplate;
		GameData gameData;
	
		void Start ()
		{
				gameData = GetComponent<GameData> ();
		}
	
		void startGame ()
		{
				prepareCells ();
				prepareAIMode ();
				SendMessage ("GameStarted");
		}

		void prepareAIMode ()
		{
				if (Random.Range (1, GameGlobals.AI_FIRST_PROBABILITY) == 1)
						gameData.AIfirst = true;
				else
						gameData.AIfirst = false;
		}

		void prepareCells ()
		{
				gameData.Reset ();
				GameObject newCell;
				Quaternion cellRot = cellTemplate.transform.rotation;
				int count = 0;
				for (int i = 0; i < GameGlobals.CELLS_WIDTH; i++) {
						for (int j = 0; j < GameGlobals.CELLS_WIDTH; j++) {
								Vector3 templateCellPos = cellTemplate.transform.position;
								templateCellPos.x += j * GameGlobals.CELL_MARGIN;
								templateCellPos.y -= i * GameGlobals.CELL_MARGIN;
								newCell = (GameObject)Object.Instantiate (cellTemplate, templateCellPos, cellRot);
								newCell.SendMessage ("SetIndex", new Vector3 (j, i, count));
								Cell cellComponent = newCell.GetComponent<Cell> ();
								gameData.cells.Add (cellComponent.GetKey (), cellComponent);
								gameData.freeCells.Add (cellComponent.GetKey (), cellComponent);
								count++;
						}
				}
		}

		void playerTurned (Cell cell)
		{
				turned (cell);
				SendMessage ("CalcWin");
				if (gameData.modeAI && !gameData.gameOver)
						SendMessage ("StepAI");
		}

		void AITurned (Cell cell)
		{
				turned (cell);
				SendMessage ("CalcWin");
		}

		void turned (Cell cell)
		{
				gameData.playerOneTurn = !gameData.playerOneTurn;
				gameData.freeCells.Remove (cell.GetKey ());
				if (cell.GetCellType () == GameGlobals.CELL_X)
						gameData.xCells.Add (cell.GetKey (), cell);
				else
						gameData.oCells.Add (cell.GetKey (), cell);
		}

		void PlayerVsPlayer ()
		{
				gameData.modeAI = false;
				startGame ();
		}

		void PlayerVsAI ()
		{
				gameData.modeAI = true;
				startGame ();
		}

		void NewGame ()
		{
				foreach (Cell cell in gameData.cells.Values) {
						GameObject.Destroy (cell.gameObject);
				}
				SendMessage ("GameEnded");
		}

}
