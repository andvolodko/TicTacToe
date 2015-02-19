using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour
{
		GameObject ticTacToe;
		GameData gameData;
		TextMesh caption;
		MeshCollider cellCollider;
		string type;
		bool finished = false;
		int x;
		int y;
		int cellPosition;
		public GameObject cellBackround;
		
		void Start ()
		{
				ticTacToe = GameObject.Find ("TicTacToe");
				gameData = ticTacToe.GetComponent<GameData> ();
				cellCollider = GetComponentInChildren<MeshCollider> ();
				caption = GetComponentInChildren<TextMesh> ();
				caption.renderer.enabled = false;
		}

		public void SetIndex (Vector3 vec)
		{
				x = (int)vec.x;
				y = (int)vec.y;
				cellPosition = (int)vec.z;
		}

		public string GetKey ()
		{
				return x + GameGlobals.CELLS_SEPARATOR + y;
		}

		public int GetCellPosition ()
		{
				return cellPosition;
		}

		public bool CompareIndex (Vector3 combi)
		{
				return (combi.x != cellPosition || combi.y != cellPosition || combi.z != cellPosition);
		}

		void ClikedBase ()
		{
				cellCollider.enabled = false;
				finished = true;
				if (gameData.playerOneTurn) {
						caption.text = GameGlobals.CELL_X;
						type = GameGlobals.CELL_X;
				} else {
						caption.text = GameGlobals.CELL_O;
						type = GameGlobals.CELL_O;
				}
				//caption.text = GetCellPosition ().ToString();
				caption.renderer.enabled = true;
				Debug.Log ("cell click");
				AnimateText ();
		}

		void cellClicked ()
		{
				ClikedBase ();
				ticTacToe.SendMessage ("playerTurned", this);
		}

		public void AIClicked ()
		{
				ClikedBase ();
				ticTacToe.SendMessage ("AITurned", this);
		}

		void AnimateText ()
		{
				caption.gameObject.transform.localScale = new Vector3 ();
				iTween.ScaleTo (caption.gameObject, iTween.Hash ("scale", new Vector3 (1.2f, 1.2f, 1.2f), "time", 0.2f, "easetype", iTween.EaseType.easeInOutSine));
				iTween.ScaleTo (caption.gameObject, iTween.Hash ("scale", new Vector3 (1f, 1f, 1f), "delay", 0.2f, "time", 0.2f, "easetype", iTween.EaseType.easeInOutSine));
		}

		public bool IsFinished ()
		{
				return finished;
		}

		public string GetCellType ()
		{
				return type;
		}

		public void SetWin ()
		{
				cellBackround.renderer.material.color = new Color32 (245, 108, 55, 255);
		}

		public void SetLose ()
		{
				finished = true;
				cellCollider.enabled = false;
		}
	
		public void Freeze ()
		{
				cellCollider = GetComponentInChildren<MeshCollider> ();
				if (!finished)
						cellCollider.enabled = false;
		}

		public void UnFreeze ()
		{
				cellCollider = GetComponentInChildren<MeshCollider> ();
				if (!finished)
						cellCollider.enabled = true;
		}

}
