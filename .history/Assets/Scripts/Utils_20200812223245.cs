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
			gameObject.enabled = on;
				if (gameObject.GetComponent<MeshRenderer>())
						gameObject.GetComponent<MeshRenderer>().enabled = on;
				MeshRenderer[] mrenderers = gameObject.GetComponentsInChildren<MeshRenderer> ();
				foreach (MeshRenderer mrenderer in mrenderers) {
						mrenderer.enabled = on;
				}

				if (gameObject.GetComponent<Renderer>())
						gameObject.GetComponent<Renderer>().enabled = on;
				Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer> ();
				foreach (Renderer renderer in renderers) {
						renderer.enabled = on;
				}

				if (gameObject.GetComponent<Collider>())
						gameObject.GetComponent<Collider>().enabled = on;
				Collider[] colliders = gameObject.GetComponentsInChildren<Collider> ();
				foreach (Collider collider in colliders) {
						collider.enabled = on;
				}
		}
}
