using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour
{
	
		void Start ()
		{
				switchSelectMenu (true);
		}

		void PlayerVsPlayer ()
		{
				switchSelectMenu (false);
		}
	
		void PlayerVsAI ()
		{
				switchSelectMenu (false);
		}

		void OnlineGame ()
		{
				switchSelectMenu (false);
		}

		void NewGame ()
		{
				switchSelectMenu (true);
		}
	
		void switchSelectMenu (bool on)
		{
				GameObject[] staticObject = GameObject.FindGameObjectsWithTag ("SelectMode");
				foreach (GameObject obj in staticObject) {
						if (obj.renderer) {
								if (on)
										obj.renderer.enabled = true;
								else
										obj.renderer.enabled = false;
						} 
						if (obj.collider) {
								if (on)
										obj.collider.enabled = true;
								else
										obj.collider.enabled = false;
						} 
				}
				GameObject newGameButton = GameObject.Find ("NewGameButton");
				if (on)
						Utils.hideGameObject (newGameButton);
				else
						Utils.showGameObject (newGameButton);

		}
}
