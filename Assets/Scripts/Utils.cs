using UnityEngine;
using System.Collections;

public class Utils : MonoBehaviour
{

	
		public static void showGameObject (GameObject gameObject)
		{
				switchObject (gameObject, true);
		}

		public static void hideGameObject (GameObject gameObject)
		{
				switchObject (gameObject, false);
		}

		private static void switchObject (GameObject gameObject, bool on)
		{
				if (gameObject.renderer)
						gameObject.renderer.enabled = on;
				Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer> ();
				foreach (Renderer renderer in renderers) {
						renderer.enabled = on;
				}

				if (gameObject.collider)
						gameObject.collider.enabled = on;
				Collider[] colliders = gameObject.GetComponentsInChildren<Collider> ();
				foreach (Collider collider in colliders) {
						collider.enabled = on;
				}
		}
}
