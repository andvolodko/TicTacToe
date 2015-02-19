using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameData : MonoBehaviour
{

		public Dictionary<string, Cell> cells;
		public Dictionary<string, Cell> oCells;
		public Dictionary<string, Cell> xCells;
		public Dictionary<string, Cell> freeCells;
		public bool playerOneTurn = true;
		public bool modeAI = false;
		public bool AIfirst = false;
		public bool gameOver = false;
		public Vector3[] combos;

		public void Reset ()
		{
				cells = new Dictionary<string, Cell> ();
				oCells = new Dictionary<string, Cell> ();
				xCells = new Dictionary<string, Cell> ();
				freeCells = new Dictionary<string, Cell> ();
				playerOneTurn = true;
				gameOver = false;
		}
	
		void Start ()
		{
				combos = new Vector3[8];
				combos [0] = new Vector3 (0, 1, 2);
				combos [1] = new Vector3 (3, 4, 5);
				combos [2] = new Vector3 (6, 7, 8);
				combos [3] = new Vector3 (0, 3, 6);
				combos [4] = new Vector3 (1, 4, 7);
				combos [5] = new Vector3 (2, 5, 8);
				combos [6] = new Vector3 (0, 4, 8);
				combos [7] = new Vector3 (2, 4, 6);
		}

}
