using UnityEngine;
using System.Collections;

public class BaseButton : MonoBehaviour
{
		protected GameObject ticTacToe;
		Renderer cellRenderer;
		Color32 outColor = new Color32 (143, 122, 102, 255);
		Color32 overColor = new Color32 (165, 144, 125, 255);
		
		void Start ()
		{
				ticTacToe = GameObject.Find ("TicTacToe");
				cellRenderer = GetComponent<Renderer> ();
				cellRenderer.material.color = outColor;
		}

		void OnMouseEnter ()
		{
				cellRenderer.material.color = overColor;
		}

		void OnMouseExit ()
		{
				cellRenderer.material.color = outColor;
		}

}
