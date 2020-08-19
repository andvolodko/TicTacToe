using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class GameSounds : MonoBehaviour
{

		public AudioClip click;
		public AudioClip won;

		void PlayerVsPlayer ()
		{
				GetComponent<AudioSource>().PlayOneShot (click);
		}
	
		void PlayerVsAI ()
		{
				GetComponent<AudioSource>().PlayOneShot (click);
		}

		void OnlineGame ()
		{
				GetComponent<AudioSource>().PlayOneShot (click);
		}

		void NewGame ()
		{
				GetComponent<AudioSource>().PlayOneShot (click);
		}

		void playerTurned ()
		{
				GetComponent<AudioSource>().PlayOneShot (click);
		}

		void AITurned ()
		{
				GetComponent<AudioSource>().PlayOneShot (click);
		}

		void XWon ()
		{
				GetComponent<AudioSource>().PlayOneShot (won);
		}

		void OWon ()
		{
				GetComponent<AudioSource>().PlayOneShot (won);
		}

}
